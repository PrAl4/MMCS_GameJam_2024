using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed = 3f;
    private Rigidbody2D rb;
    private Vector2 move;
    //private Animator animator;
    private Vector2 zero = new Vector2(0, 0);

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        //animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        //animator.SetBool("IsRuning", false);
        move = new Vector2(Input.GetAxis("Horizontal"), 0);
        if (move != zero)
        {
            //animator.SetBool("IsRuning", true);
            Vector2 velocity = new Vector2(move[0] * speed, rb.velocity.y);

            rb.velocity = velocity;
        }
        

    }
}
