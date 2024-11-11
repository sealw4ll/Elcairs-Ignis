using Microsoft.Win32.SafeHandles;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.XInput;
using UnityEngine.UIElements;

public class playerScript : MonoBehaviour
{
    public float acceleration = 1f;

    private float horizontalInput;

    [SerializeField] private float maxSpeed = 8f;
    [SerializeField] private float jumpSpeed = 16f;

    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D feetCollider;
    [SerializeField] private LayerMask groundLayer;

    public ManaManagement manaStore;

    private uint jumps;
    [SerializeField] private uint maxJumps = 2;
    [SerializeField] private uint forceJumpMana = 1;

    private bool isDashing = false;
    [SerializeField] private float dashSpeed = 24f;
    [SerializeField] private uint dashManaCost = 1;

    [Range(0f, 1f)] public float groundDrag = 0.5f;
    [Range(0f, 1f)] public float dashingDrag = 0.9f;
     
    private float coyoteTime = 0.1f;
    private float coyoteTimeCounter = 0f;

    private float jumpBufferTime = 0.03f;
    private float jumpBufferTimeCounter = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumps = maxJumps;
    }

    private void getInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
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

    private void moveChar()
    {
        if (Mathf.Abs(horizontalInput) > 0)
        {
            float increment = horizontalInput * acceleration;
            float newSpeed = Mathf.Clamp(rb.linearVelocity.x + increment, -maxSpeed, maxSpeed);

            float oldSpeed = rb.linearVelocity.x;

            rb.linearVelocity = new Vector2(
                Mathf.Abs(oldSpeed) > Mathf.Abs(newSpeed) ? oldSpeed : newSpeed, 
                rb.linearVelocity.y
               );
            FaceInput();
        }
    }

    private void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && manaStore.enoughMana(dashManaCost)) // TODO: Change this
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x + (dashSpeed * Mathf.Sign(transform.localScale.x)), rb.linearVelocity.y);
            manaStore.decreaseMana(dashManaCost);
            isDashing = true;
        }
    }

    private void HandleJump()
    {
        bool grounded = IsGrounded();

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

        if (jumpBufferTimeCounter > 0f && (coyoteTimeCounter > 0f || grounded || jumps > 0 || manaStore.enoughMana(forceJumpMana)))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
            if (!grounded)
            {
                if (jumps <= 0)
                    manaStore.decreaseMana(forceJumpMana);
                else if (coyoteTimeCounter <= 0f)
                    jumps -= 1;
            }
            coyoteTimeCounter = 0f;
            jumpBufferTimeCounter = 0f;
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
            if (Mathf.Abs(rb.linearVelocity.x) < maxSpeed)
                isDashing = false;
        }
        else
        {
            if (IsGrounded() && horizontalInput == 0 && rb.linearVelocity.y <= 0)
                rb.linearVelocity *= groundDrag; // tf
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
