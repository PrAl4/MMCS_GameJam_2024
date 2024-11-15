using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed = 3f;
    private Rigidbody2D rb;
    private float move;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;
    private Animator animator;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb.inertia = 0;
    }


    void Start()
    {
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            Jump();
        }
    }

    void FixedUpdate()
    {

        float inputAxis = Input.GetAxis("Horizontal");
        if (inputAxis == 0)
        {
            rb.velocity = new Vector2(0f, rb.velocity.y) ;
        }
        else
        {
            Vector2 velocity = rb.velocity;
            velocity.x = inputAxis * speed;
            rb.velocity = velocity;


            if (inputAxis > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (inputAxis < 0)
            {
                spriteRenderer.flipX = true;
            }
        }
        if (isGrounded)
        {
            if (inputAxis != 0)
            {
                animator.SetBool("IsRuning", true);
            }
            else
            {
                animator.SetBool("IsRuning", false);
            }
        }

    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 7f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isGrounded)
        {
            isGrounded = collision.contacts.All(c => c.point.y < transform.position.y);
            Debug.Log(isGrounded);
        }
        Debug.Log(isGrounded);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        isGrounded = collision.contacts.All(c => c.point.y > transform.position.y);
        Debug.Log(isGrounded);


    }
}
