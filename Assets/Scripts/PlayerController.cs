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
    CharacterController characterController;
    private Vector2 zero = new Vector2(0, 0);

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        animator.SetBool("IsRuning", false);
        move = transform.TransformDirection(Vector2.right);
        if (move != zero)
        {
            animator.SetBool("IsRuning", true);
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        

    }
}
