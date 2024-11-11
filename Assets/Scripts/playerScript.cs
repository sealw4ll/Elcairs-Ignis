using UnityEngine;

public class playerScript : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D hitBoxCollider;
    [SerializeField] private BoxCollider2D dashingHitBox;
    [SerializeField] private BoxCollider2D feetCollider;
    [SerializeField] private LayerMask groundLayer;

    public ManaManagement manaStore;

    private int jumps;
    [SerializeField] private int maxJumps = 2;
    [SerializeField] private int forceJumpMana = 1;

    private bool isDashing = false;
    [SerializeField] private int dashManaCost = 1;

    [Range(0f, 1f)] public float groundDrag = 0.5f;
    [Range(0f, 1f)] public float dashingDrag = 0.9f;

    private float initialGravity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumps = maxJumps;
        hitBoxCollider.enabled = true;
        dashingHitBox.enabled = false;
        initialGravity = rb.gravityScale;
    }

    private void getInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
        HandleJump();
        HandleDash();

        // reset jump count
        if (IsGrounded())
        {
            jumps = maxJumps;
        }
    }

    private void moveChar()
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
            FaceInput();
        }
    }

    private void activateDash()
    {
        manaStore.decreaseMana(dashManaCost);
        hitBoxCollider.enabled = false;
        dashingHitBox.enabled = true;
        isDashing = true;
        rb.gravityScale = 0;
    }

    private void deactivateDash()
    {
        hitBoxCollider.enabled = true;
        dashingHitBox.enabled = false;
        isDashing = false;
        rb.gravityScale = initialGravity;
    }

    private void HandleDash()
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

    private void HandleJump()
    {
        bool grounded = IsGrounded();

        if (Input.GetButtonDown("Jump") && (grounded || jumps > 0 || manaStore.enoughMana(forceJumpMana)))
        {
            if (!grounded)
            {
                if (jumps <= 0)
                    manaStore.decreaseMana(forceJumpMana);
                else
                    jumps -= 1;
            }
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, manaStore.getJumpSpeed());
        }
    }

    void FixedUpdate()
    {
        moveChar();
        ApplyFiction();
    }

    private void ApplyFiction()
    {
        if (isDashing)
        {
            rb.linearVelocity *= dashingDrag;
            if (Mathf.Abs(rb.linearVelocity.x) <= manaStore.getRunSpeed() && 
                Mathf.Abs(rb.linearVelocity.y) <= manaStore.getJumpSpeed())
            {
                deactivateDash();
            }
        }
        else
        {
            if (IsGrounded() && horizontalInput == 0 && rb.linearVelocity.y <= 0)
                rb.linearVelocity *= groundDrag;
        }

    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapAreaAll(feetCollider.bounds.min, feetCollider.bounds.max, groundLayer).Length > 0;
    }

    private void FaceInput()
    {
        float direction = Mathf.Sign(horizontalInput);
        Vector3 newScale = transform.localScale;
        newScale.x = Mathf.Abs(newScale.x) * direction;
        transform.localScale = newScale;
    }
}
