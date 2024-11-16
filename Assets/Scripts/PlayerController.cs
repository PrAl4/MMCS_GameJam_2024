using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed = 3f;
    [SerializeField] int weaponKey = 0;
    private bool isAttack = false;
    private Rigidbody2D rb;
    private float move;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public GameObject BraidHitArea;
    BraidAreaTrigger braidHitArea;
    public int WeaponKey    // 0 - без, 1 - коса, 2 - щит, 3 - посох, 4 - лазер
    {
        get { return weaponKey; }
        set
        {
            weaponKey = value;
            animator.SetInteger("WeaponKey", weaponKey);
        }
    }
    public bool IsAttack 
    {
        get { return isAttack; }
        set
        {
            isAttack = value;
            animator.SetBool("IsAttack", isAttack);
        }
    }

    void ResetAttack()
    {
        IsAttack = false;
    }

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
        WeaponKey = weaponKey;
        braidHitArea = BraidHitArea.GetComponent<BraidAreaTrigger>();
    }

    void Update()
    {
        if(rb.velocity.y == 0)
        {
            isGrounded = true;
        }
        else { isGrounded = false; }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && isGrounded && !IsAttack)
        {
            IsAttack = true;
            if (WeaponKey == 1)
            {
                List<GameObject> triggers = braidHitArea.GetTriggers();
                foreach (GameObject trigger in triggers)
                {
                    Debug.Log(trigger);     // здесь будет наносится урон по RedEnemy
                }
            }
        }

        for (int i = 0; i < 4; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                WeaponKey = i + 1;
            }
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
                braidHitArea.FlipHitArea(false);
                spriteRenderer.flipX = false;
            }
            else if (inputAxis < 0)
            {
                braidHitArea.FlipHitArea(true);
                spriteRenderer.flipX = true;
            }
        }
        if (isGrounded)
        {
            animator.SetBool("IsJumping", false);
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
        animator.SetBool("IsJumping", true);
    }

}
