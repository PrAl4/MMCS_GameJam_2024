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

    public GameObject SnowBall;
    public GameObject Laser;
    public float SnowBallTimerDuration = 0.5f;
    private bool snowBallTimerActive = false;

    public GameObject BraidHitArea;
    BraidAreaTrigger braidHitArea;
    private SoundManager soundManager;
    public int WeaponKey    //0 - без, 1 - коса, 2 - щит, 3 - посох, 4 - лазер. ћен€ть каждый раз при переключении оружи€.
    {
        get { return weaponKey; }
        set
        {
            weaponKey = value;
            animator.SetInteger("WeaponKey", weaponKey);
        }
    }
    public bool IsAttack  //ѕо сути только дл€ удара косой
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
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }

    void Update()
    {
        if(rb.velocity.y == 0)
        {
            isGrounded = true;
            soundManager.StoppedJumping();
        }
        else { isGrounded = false; }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && isGrounded && !IsAttack)
        {
            if (WeaponKey == 1)
            {
                IsAttack = true;
                soundManager.Play("Braid");
                List<GameObject> triggers = braidHitArea.GetTriggers();
                foreach (GameObject trigger in triggers)
                {
                    Debug.Log(trigger);     //здесь будет наноситс€ урон косой по RedEnemy. trigger - red enemy.
                }
            }
            else if (WeaponKey == 3 && !snowBallTimerActive) {

                soundManager.Play("Staff");

                StartCoroutine(StartTimer());
                int dir = 2 * (spriteRenderer.flipX ? 1 : 0) - 1;
                GameObject instance = Instantiate(SnowBall, transform.position + new Vector3(0.5f * -dir, 0, 0), Quaternion.identity);
                SnowBallController snowBall = instance.GetComponent<SnowBallController>();
                snowBall.setDirection(-dir);
            }
            else if (WeaponKey == 4 && !snowBallTimerActive)
            {

                StartCoroutine(StartTimer());
                int dir = 2 * (spriteRenderer.flipX ? 1 : 0) - 1;
                GameObject instance = Instantiate(Laser, transform.position + new Vector3(0.5f * -dir, 0, 0), Quaternion.identity);
                LaserController laser = instance.GetComponent<LaserController>();
                laser.setDirection(-dir);
            }
        }

        for (int i = 0; i < 4; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))   //смена оружи€ на 1, 2, 3, 4.
            {
                WeaponKey = i + 1;
                soundManager.Play("ChangeWeapon");
                soundManager.PlaySoundtrack(WeaponKey);
            }
        }
    }

    private IEnumerator StartTimer()
    {
        snowBallTimerActive = true;
        yield return new WaitForSeconds(SnowBallTimerDuration);
        snowBallTimerActive = false;
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
        soundManager.Jumping();
    }

}
