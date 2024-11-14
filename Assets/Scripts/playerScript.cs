using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;

    public Rigidbody2D rb;
    [SerializeField] private BoxCollider2D hitBoxCollider;
    [SerializeField] private GameObject dashingHitBox;

    public ManaManagement manaStore;

    private int jumps;
    [SerializeField] public int maxJumps = 2;
    [SerializeField] public int forceJumpMana = 1;

    public bool isDashing { get; protected set; } = false;
    [SerializeField] public int dashManaCost = 1;

    [Range(0f, 1f)] public float groundDrag = 0.5f;
    [Range(0f, 1f)] public float dashingDrag = 0.9f;

    [SerializeField] public GroundSensor groundSensor;

    public float coyoteTime = 0.1f;
    private float coyoteTimeCounter = 0f;

    public float jumpBufferTime = 0.03f;
    private float jumpBufferTimeCounter = 0f;

    public bool damaged { get; protected set; }
    public float doubleJumpPenality = 0.5f;

    public bool isIdle()
    {
        return (Mathf.Abs(rb.linearVelocityX) < 0.1f && groundSensor.isGrounded);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumps = maxJumps;
        damaged = false;
        hitBoxCollider.enabled = true;
        dashingHitBox.SetActive(false);
    }

    public void getInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            return;
        }

        if (isDashing) {
            rb.gravityScale = 0;
        } else {
            rb.gravityScale = manaStore.getGravityScale();
        }

        getInput();
        HandleJump();
        HandleDash();

        // reset jump count
        if (groundSensor.isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
            jumps = maxJumps;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferTimeCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferTimeCounter -= Time.deltaTime;
        }
    }

    public void moveChar()
    {
        if (Mathf.Abs(horizontalInput) > 0 && !isDashing)
        {

            if (Mathf.Sign(horizontalInput) != Mathf.Sign(rb.linearVelocity.x))
            {
                // immediately change direction
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            }

            float acc = horizontalInput * manaStore.getRunAcceleration();
            float maxRunSpeed = manaStore.getRunSpeed();
            float newSpeed = Mathf.Clamp(rb.linearVelocity.x + acc, -maxRunSpeed, maxRunSpeed);
            rb.linearVelocity = new Vector2(
                newSpeed,
                rb.linearVelocity.y
            );
        }
    }

    public void activateDash()
    {
        manaStore.decreaseMana(dashManaCost);
        hitBoxCollider.enabled = false;
        dashingHitBox.SetActive(true);
        isDashing = true;
    }

    public void deactivateDash()
    {
        hitBoxCollider.enabled = true;
        dashingHitBox.SetActive(false);
        isDashing = false;
    }

    public void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && manaStore.enoughMana(dashManaCost)) // TODO: Change this
        {
            float newY = (verticalInput != 0) ? manaStore.getDashSpeed() * Mathf.Sign(verticalInput) : 0f;
            float newX = (horizontalInput != 0) ? manaStore.getDashSpeed() * Mathf.Sign(horizontalInput) : 0f;
            Vector2 dirVec = new Vector2(newX, newY);
            dirVec.Normalize();

            if (newX == 0 && newY == 0)
            {
                rb.linearVelocity = new Vector2(
                    rb.linearVelocity.x + ( manaStore.getDashSpeed() * Mathf.Sign(transform.localScale.x)),
                    rb.linearVelocity.y
                );
            } else
            {
                dirVec *= manaStore.getDashSpeed();
                rb.linearVelocity = rb.linearVelocity + dirVec;
            }


            activateDash();
        }
    }

    public void HandleJump()
    {
        bool grounded = groundSensor.isGrounded;

        // if (Input.GetButtonDown("Jump") && (grounded || jumps > 0 || manaStore.enoughMana(forceJumpMana)))
        // {
        //     rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
        //     if (!grounded)
        //     {
        //         if (jumps <= 0)
        //             manaStore.decreaseMana(forceJumpMana);
        //         else
        //             jumps -= 1;
        //     }
        //     coyoteTimeCounter = 0f;
        //     jumpBufferTimeCounter = 0f;
        // }

        bool doubleJump = false;
        if (jumpBufferTimeCounter > 0f && (coyoteTimeCounter > 0f || grounded || jumps > 0 || manaStore.enoughMana(forceJumpMana)))
        {
            if (!grounded)
            {
                doubleJump = true;
                if (jumps <= 0)
                    manaStore.decreaseMana(forceJumpMana);
                else if (coyoteTimeCounter <= 0f)
                    jumps -= 1;
            }
            coyoteTimeCounter = 0f;
            jumpBufferTimeCounter = 0f;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x,  ( manaStore.getJumpSpeed() * (doubleJump ? doubleJumpPenality : 1f) ) );
        }
    }

    public void toggleDamaged()
    {
        damaged = !damaged;
    }

    void FixedUpdate()
    {
        if (damaged)  return;
        moveChar();
        ApplyFiction();
    }

    public void ApplyFiction()
    {
        if (isDashing)
        {
            rb.linearVelocity *= dashingDrag;
            if (Mathf.Abs(rb.linearVelocity.x) <= manaStore.getRunSpeed() &&
                Mathf.Abs(rb.linearVelocity.y) <= manaStore.getJumpSpeed())
            {
                if (Mathf.Abs(rb.linearVelocity.x) >= Mathf.Abs(rb.linearVelocity.y))
                    rb.linearVelocityX = manaStore.getRunSpeed() * Mathf.Sign(rb.linearVelocityX);
                deactivateDash();
            }
        }
        else
        {
            if (groundSensor.isGrounded && horizontalInput == 0 && rb.linearVelocity.y <= 0.1f)
            {
                rb.linearVelocity *= groundDrag;
            }
        }

    }
}
