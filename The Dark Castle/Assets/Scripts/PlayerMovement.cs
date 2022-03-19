using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    new BoxCollider2D collider;
    public float MoveSpeed = 0f;
    public float JumpPower = 0f;
    public LayerMask GroundLayer;
    public LayerMask WallLayer;
    private float horizontalInput = 0f;
    
    
    float wallJumpCoolDown = 0f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
       
        //flip player when moving left-right
        if (horizontalInput >= 0.01f)
            transform.localScale = Vector2.one;
        else if (horizontalInput <= -0.01f)
            transform.localScale = new Vector2(-1, 1);

        //set Animator Parameter
        animator.SetBool("run", horizontalInput != 0);
        animator.SetBool("grounded", IsGrounded());

        //Mekanik Wall Jump
        if (wallJumpCoolDown > 0.2f)
        {

            rb.velocity = new Vector2(horizontalInput * MoveSpeed, rb.velocity.y);

            if (OnWall() && !IsGrounded())
            {
                rb.gravityScale = 0;
                rb.velocity = Vector2.zero;
            }
            else
                rb.gravityScale = 5f;

            if (Input.GetKey(KeyCode.Space))
                Jump();
        }
        else
        {
            wallJumpCoolDown += Time.deltaTime;
        }
    }
    private void Jump()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpPower);
            animator.SetTrigger("jump");
        } else if (OnWall() && !IsGrounded())
        {
            if (horizontalInput == 0)
            {
                rb.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                rb.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 2, 5);

            wallJumpCoolDown = 0f;
            
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Ground")
    //        grounded = true;
    //}

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0, Vector2.down, 0.1f, GroundLayer);
        return raycastHit.collider != null;
    }
    private bool OnWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, WallLayer);
        return raycastHit.collider != null;
    }
    public bool CanAttack()
    {
        return horizontalInput == 0 && IsGrounded() && !OnWall();
    }
}
