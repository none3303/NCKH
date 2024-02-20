using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    float x;
    float JumpForce = 16;
    Animator animator;
    private bool canMove = true;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Player Movement
        if (canMove)
        {
            x = Input.GetAxis("Horizontal");
            if (x < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (x > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (Input.GetButtonDown("Jump") && isGround())
            {
                
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);

            }

            //Animation Controlling
            if (x != 0f && rb.velocity.y == 0)
            {
                animator.Play("player_run");
            }
            else
            {
                if (rb.velocity.y == 0)
                    animator.Play("player_idle");
            }
            if (!isGround())
            {
                animator.Play("player_jump");
            }
        }
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
    }
    private bool isGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void OnLock()
    {
        canMove = false;
    }
    public void Unlock()
    {
        canMove = true;
    }
    public void Dead()
    {
        animator.Play("player_hurt");
        Invoke("DestroyThis", 1.1f);
        
    }
    private void DestroyThis()
    {
        Destroy(gameObject);
    }
}
