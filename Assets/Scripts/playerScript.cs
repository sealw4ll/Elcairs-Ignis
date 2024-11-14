using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float lastX = 1;
    public float horizontalInput;
    public float verticalInput;

    public bool dying = false;

    public EffectGenerator jumpEffect;

    public GameObject playerObj;
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

    public float dashTimer = 0f;
    public float maxDashTimer = 0.5f;

    public PlayerAttack pAtk;

    public bool dead;

    public Health health;

    public float jumpCut = 0.5f;


    public bool isIdle()
    {
        return (Mathf.Abs(rb.linearVelocityX) < 0.1f && groundSensor.isGrounded);
    }

    public void resetPlayer()
    {
        rb.linearVelocity = Vector2.zero;
        playerObj.SetActive(true);

        jumps = maxJumps;

        health.regen();

        dying = false;
        dead = false;
        damaged = false;

        isDashing = false;

        hitBoxCollider.enabled = true;
        dashingHitBox.SetActive(false);
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
        if (horizontalInput != 0)
            lastX = horizontalInput;
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged || dead || dying)
        {
            return;
        }

        if (isDashing) {
            rb.gravityScale = 0;
        } else {
            rb.gravityScale = manaStore.getGravityScale();
        }

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

        getInput();
        HandleJump();
        HandleDash();
        HandleAtk();

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferTimeCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferTimeCounter -= Time.deltaTime;
        }

        if (!groundSensor.isGrounded && !isDashing)
        {
            float maxAirSpeed = manaStore.getMaxAirSpeed();
            rb.linearVelocityX = Mathf.Clamp(rb.linearVelocityX, -maxAirSpeed, maxAirSpeed);
        }
        else if (groundSensor.isGrounded && !isDashing)
        {
            float maxGroundSpeed = manaStore.getRunSpeed();
            rb.linearVelocityX = Mathf.Clamp(rb.linearVelocityX, -maxGroundSpeed, maxGroundSpeed);
        }

        if (isDashing)
        {
            dashTimer += Time.deltaTime;
        }
    }


    private void HandleAtk()
    {
        if (Input.GetMouseButtonDown(0)) // TODO: Change Key 
        {
            float xInput = horizontalInput;
            float yInput = verticalInput;
            if (xInput == 0 && yInput == 0)
                xInput = lastX;
            pAtk.Attack(xInput, yInput);
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
            float newSpeed = rb.linearVelocity.x + acc;

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
        dashTimer = 0f;
    }

    public void deactivateDash()
    {
        hitBoxCollider.enabled = true;
        dashingHitBox.SetActive(false);
        isDashing = false;
        dashTimer = 0f;
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
                    ( manaStore.getDashSpeed() * lastX ),
                    0
                );
            } else
            {
                dirVec *= manaStore.getDashSpeed();
                rb.linearVelocity = dirVec;
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
        if (jumpBufferTimeCounter > 0f && (coyoteTimeCounter > 0.001f || grounded || jumps > 0 || manaStore.enoughMana(forceJumpMana)))
        {
            if (!grounded)
            {
                if (jumps <= 0)
                {
                    doubleJump = true;
                    manaStore.decreaseMana(forceJumpMana);
                }
                else if (coyoteTimeCounter <= 0f)
                {
                    doubleJump = true;
                    jumps -= 1;
                }
            }
            coyoteTimeCounter = 0f;
            jumpBufferTimeCounter = 0f;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x,  ( manaStore.getJumpSpeed() * (doubleJump ? doubleJumpPenality : 1f) ) );
            jumpEffect.generate();
        }

        if (rb.linearVelocityY > 0f && !isDashing && Input.GetButtonUp("Jump")) {
            rb.linearVelocityY *= jumpCut;
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
            if (dashTimer > maxDashTimer)
            {
                deactivateDash();
                // rb.linearVelocity *= dashingDrag;
            }
            /*
                if (Mathf.Abs(rb.linearVelocity.x) <= manaStore.getRunSpeed() && 
                    Mathf.Abs(rb.linearVelocity.y) <= manaStore.getJumpSpeed())
                {
                    if (Mathf.Abs(rb.linearVelocity.x) >= Mathf.Abs(rb.linearVelocity.y))
                        rb.linearVelocityX = manaStore.getRunSpeed() * Mathf.Sign(rb.linearVelocityX);
                }
            */
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
