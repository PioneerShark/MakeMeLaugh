using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : BaseEntity
{
    public Animator animator;

    [Header("Player")]
    [SerializeField] private float speed;
                     private float horizontal;
                     public BoxCollider2D bc;
                     private bool isFacingRight = true;
                     Hands hand;

    [Header("Jumping")]
    [SerializeField] private float jumpPower;
                     //private bool isGrounded;

    [Header("Wall Movement")]
    [SerializeField] private float wallJumpingTime = 0.5f;                      // I don't understand the use case of this, when it's 0 wall jumping does not happen, but anything above that it will work
    [SerializeField] private float wallJumpingDuration = 0.25f;                 // How long before the wall jump stops
    [SerializeField] private Vector2 wallJumpingPower = new Vector2(5f, 16f);   // The force from wall jumping horizontally and vertically
                     private bool isWallJumping;
                     private float wallJumpingDirection;                        // Current direction towards wall
                     private float wallJumpingCounter;                          // How much time left before jumping again

                     //private bool isWalled;                                     // If touching wall
                     private bool isWallSliding;                                // If currently wall sliding
    [SerializeField] private float wallSlidingSpeed = 1.5f;                     // Speed of wall

    [Header("Ground Check")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector2 groundCheckSize;

    [Header("Wall Check")]
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private Vector2 wallCheckSize;
    private void Awake()
    {
        hand = GetComponent<Hands>();
    }

    //bool m_started;
    void Start()
    {
        //m_started = true;
    }

    void Update()
    {
        //WallJump();
        WallSlide();
    
        if (!isWallJumping) { Flip(); }
        
        //animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        //animator.SetBool("IsFacingRight",  isFacingRight);
        //animator.SetBool("IsGrounded", isGrounded());
    }

    void FixedUpdate()
    {
        if (!isWallJumping) { rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); }
    }

    public void Move(Vector2 context)
    {
        horizontal = context.x;
    }
    public void Fire(InputAction.CallbackContext context)
    {
        //hand.Fire();
        if (hand.Fire())
        {
            AudioManager.Instance.PlaySFX("FITH");
        }
    }
    public void Equip(GameObject equipObject)
    {
        hand.Equip(equipObject);
    }
    public void Unequip()
    {
        hand.Unequip();
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            AudioManager.Instance.PlaySFX("Cheat-o");
        }
        else if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        WallJump();

        if (context.performed && !isGrounded() && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            // Force Flip
            if (transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                transform.Rotate(0, 180, 0);
                //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z, transform.rotation.w);
                /*Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;*/

            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }

    private void WallSlide()
    {
        if (!isGrounded() && isWalled() && horizontal != 0f)
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
            AudioManager.Instance.PlaySFX("Cheat-o");
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
            //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y+180, transform.rotation.z, transform.rotation.w);
            transform.Rotate(0, 180, 0);
            /*Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;*/
        }
    }

    private void drawRayCast(RaycastHit2D rc, float extraHeight)
    {
        Color rayColor;
        if (rc.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(bc.bounds.center + new Vector3(bc.bounds.extents.x, 0), Vector2.down * (bc.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(bc.bounds.center - new Vector3(bc.bounds.extents.x, 0), Vector2.down * (bc.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(bc.bounds.center - new Vector3(bc.bounds.extents.x, bc.bounds.extents.y + extraHeight), Vector2.right * (bc.bounds.extents.x * 2f), rayColor);
    }

    private bool isGrounded()
    {
        float extraHeight = 0.25f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, extraHeight, groundLayer);

        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        Debug.DrawRay(bc.bounds.center + new Vector3(bc.bounds.extents.x, 0), Vector2.down * (bc.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(bc.bounds.center - new Vector3(bc.bounds.extents.x, 0), Vector2.down * (bc.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(bc.bounds.center - new Vector3(bc.bounds.extents.x, bc.bounds.extents.y + extraHeight), Vector2.right * (bc.bounds.extents.x * 2f), rayColor);

        return raycastHit.collider != null;
    }

    private bool isWalled()
    {
        float extraHeight = 0.25f;
        RaycastHit2D raycastHit;
        if (isFacingRight) { raycastHit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.right, extraHeight, wallLayer); }
        else               { raycastHit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.left, extraHeight, wallLayer); }
        
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        if (isFacingRight) 
        { 
            Debug.DrawRay(bc.bounds.center + new Vector3(0, bc.bounds.extents.y), Vector2.right * (bc.bounds.extents.x + extraHeight), rayColor);
            Debug.DrawRay(bc.bounds.center + new Vector3(0, -bc.bounds.extents.y), Vector2.right * (bc.bounds.extents.x + extraHeight), rayColor);
            Debug.DrawRay(bc.bounds.center + new Vector3(bc.bounds.extents.x + extraHeight, bc.bounds.extents.y), Vector2.down * (bc.bounds.extents.y * 2f), rayColor);
        }
        else
        {
            Debug.DrawRay(bc.bounds.center + new Vector3(0, bc.bounds.extents.y), Vector2.left * (bc.bounds.extents.x + extraHeight), rayColor);
            Debug.DrawRay(bc.bounds.center + new Vector3(0, -bc.bounds.extents.y), Vector2.left * (bc.bounds.extents.x + extraHeight), rayColor);
            Debug.DrawRay(bc.bounds.center + new Vector3(-bc.bounds.extents.x - extraHeight, bc.bounds.extents.y), Vector2.down * (bc.bounds.extents.y * 2f), rayColor);
        }

        return raycastHit.collider != null;
    }
}
