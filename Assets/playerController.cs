using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private float speed, health;
                     private float horizontal;
                     public Rigidbody2D rb;
                     private bool isFacingRight = true;

    [Header("Jumping")]
    [SerializeField] private float jumpPower;
                     private bool isGrounded;

    [Header("Wall Movement")]
    [SerializeField] private float wallJumpingTime = 0.5f;                      // I don't understand the use case of this, when it's 0 wall jumping does not happen, but anything above that it will work
    [SerializeField] private float wallJumpingDuration = 0.25f;                 // How long before the wall jump stops
    [SerializeField] private Vector2 wallJumpingPower = new Vector2(5f, 16f);   // The force from wall jumping horizontally and vertically
                     private bool isWallJumping;
                     private float wallJumpingDirection;                        // Current direction towards wall
                     private float wallJumpingCounter;                          // How much time left before jumping again

                     private bool isWalled;                                     // If touching wall
                     private bool isWallSliding;                                // If currently wall sliding
    [SerializeField] private float wallSlidingSpeed = 1.5f;                     // Speed of wall

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector2 groundCheckSize;

    [Header("Wall Check")]
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private Vector2 wallCheckSize;

    void Update()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0, groundLayer);
        isWalled = Physics2D.OverlapBox(wallCheck.position, wallCheckSize, 0, wallLayer);

        //WallJump();
        WallSlide();
    
        if (!isWallJumping) { Flip(); }
    }

    void FixedUpdate()
    {
        if (!isWallJumping) { rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); }
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
        else if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        WallJump();

        if (context.performed && !isGrounded && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            // Force Flip
            if (transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }

    private void WallSlide()
    {
        if (!isGrounded && isWalled && horizontal != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue)); 
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }


    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    public void TakeDamage(float damage)
    {
        health-= damage;
        if (health <= 0f)
        {
            Destroy(this);
        }
    }

}
