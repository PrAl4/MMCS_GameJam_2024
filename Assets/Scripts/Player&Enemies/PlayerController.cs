using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed = 3f;
    [SerializeField] int weaponKey = 0;

    public bool isAttack = false;
    private Rigidbody2D rb;
    public bool isGrounded;
    private SpriteRenderer spriteRenderer;

    public GameObject SnowBall;
    public GameObject Laser;
    public float SnowBallTimerDuration = 0.5f;
    private bool snowBallTimerActive = false;

    public GameObject BraidHitArea;
    BraidAreaTrigger braidHitArea;
    public SoundManager soundManager;

    public static event Action<bool> isJumping;
    public static event Action<bool> isRunning;
    public static event Action<bool> isAttacking;

    GameDataScript gameData;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb.inertia = 0;
    }

    void ResetAttack() // Event in animator for disabling scythe anim and isAttack = false after ending
    {
        isAttack = false;
        isAttacking?.Invoke(false);
    }

    void Start()
    {

        gameData = GettingGameData.GetDataObj();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        braidHitArea = BraidHitArea.GetComponent<BraidAreaTrigger>();

        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }

    void Update()
    {
        if (rb.velocity.y <= 0.001f & rb.velocity.y >= -0.001f)
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

        if (Input.GetKeyDown(KeyCode.Mouse0) && isGrounded && !isAttack)
        {
            if ((int)gameData.curGunMode == 1)
            {
                isAttacking?.Invoke(true);
                isAttack = true;
                soundManager.Play("Braid");
                //List<GameObject> triggers = braidHitArea.GetTriggers();
                //foreach (GameObject trigger in triggers)
                //{
                //   // Debug.Log(trigger);     //здесь будет наносится урон косой по RedEnemy. trigger - red enemy.
                //}
            }
            else if ((int)gameData.curGunMode == 3 && !snowBallTimerActive)
            {

                soundManager.Play("Staff");

                StartCoroutine(StartTimer());
                int dir = 2 * (spriteRenderer.flipX ? 1 : 0) - 1;
                GameObject instance = Instantiate(SnowBall, transform.position + new Vector3(0.5f * -dir, 0, 0), Quaternion.identity);
                SnowBallController snowBall = instance.GetComponent<SnowBallController>();
                snowBall.setDirection(-dir);
            }
            else if ((int)gameData.curGunMode == 4 && !snowBallTimerActive)
            {

                soundManager.Play("Laser");

                StartCoroutine(StartTimer());
                int dir = 2 * (spriteRenderer.flipX ? 1 : 0) - 1;
                GameObject instance = Instantiate(Laser, transform.position + new Vector3(0.5f * -dir, 0, 0), Quaternion.identity);
                LaserController laser = instance.GetComponent<LaserController>();
                laser.setDirection(-dir);
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
            rb.velocity = new Vector2(0f, rb.velocity.y);
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
            isJumping?.Invoke(false);
            if (inputAxis != 0)
            {
                isRunning?.Invoke(true);
            }
            else
            {
                isRunning?.Invoke(false);
            }
        }

    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 9f);
        isJumping?.Invoke(true);
        isRunning?.Invoke(false);
        soundManager.Jumping();
    }
    void CollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "RedEnemy" | collision.gameObject.tag == "BlueEnemy" | collision.gameObject.tag == "GreenEnemy" | collision.gameObject.tag == "PurpleEnemy")
        {
            if ((int)gameData.curGunMode == 2 & collision.gameObject.tag == "GreenEnemy")
            {
                GameObject.Destroy(collision.gameObject);
            }
            Die();
        }
    }
    void Die()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}