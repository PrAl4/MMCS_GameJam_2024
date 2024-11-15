using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed = 3f;
    private Rigidbody2D rb;
    private Vector2 move;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        animator.SetBool("IsRuning", false);
        if (Input.GetKey("a"))
        {
            animator.SetBool("IsRuning", true);
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else if (Input.GetKey("d"))
        {
            animator.SetBool("IsRuning", true);
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

    }
}
