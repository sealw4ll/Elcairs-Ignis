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

    private uint jumps;
    [SerializeField] private uint maxJumps = 2;

    [Range(0f, 1f)] public float groundDrag = 0.5f;
     
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

        // reset jump count
        if (IsGrounded())
        {
            jumps = maxJumps;
        }
    }

    private void moveChar()
    {
        if (Mathf.Abs(horizontalInput) > 0)
        {
            float increment = horizontalInput * acceleration;
            float newSpeed = Mathf.Clamp(rb.linearVelocity.x + increment, -maxSpeed, maxSpeed);
            
            rb.linearVelocity = new Vector2(newSpeed, rb.linearVelocity.y);
            FaceInput();
        }
    }

     private void HandleJump()
    {
        bool grounded = IsGrounded();

        if (Input.GetButtonDown("Jump") && (grounded || jumps > 0))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
            if (!grounded)
                jumps -= 1;
        }
    }

    void FixedUpdate()
    {
        moveChar();
        ApplyFiction();
    }

    private void ApplyFiction()
    {
        if (IsGrounded() && horizontalInput == 0 && rb.linearVelocity.y <= 0)
            rb.linearVelocity *= groundDrag; // tf
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
