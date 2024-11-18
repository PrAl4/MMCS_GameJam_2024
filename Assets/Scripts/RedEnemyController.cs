using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RedEnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Rigidbody2D rigidbody2d;
    private Vector2 direction = Vector2.left;
    private SpriteRenderer spriterenderer;
    private Health health;
    private float positionX;
    private bool isChecked;


    


    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        spriterenderer.flipX = false;
        health = GetComponent<Health>();
       

    }
    void Start()
    {
        rigidbody2d.velocity = direction * speed;
        positionX = rigidbody2d.position.x;
        Check();
   

    }

    void Update()

    {
        rigidbody2d.velocity = direction * speed;

    }
    void FixedUpdate()
    {
        Check();
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.tag == "Player")
        {
            PlayerController weaponKey = collision.gameObject.GetComponent<PlayerController>();
            if (weaponKey.WeaponKey == 2)
            {
                health.TakeDamage(1f);
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
        else
        {
            if (!(rigidbody2d.velocity.x <= 1.5f & rigidbody2d.velocity.x >= -1.5f))
            {
                //Debug.Log(true);
                ChangeDirection();
                

            }
        }
    }
    
    void Check()
    {
        
            if (WaitForASecond())
            {
                ChangeDirection();
            }
        
    }
    bool Check2(float x)
    {
        if (rigidbody2d.position.x == x)
        {
            return isChecked =true;
        }
        else { return isChecked = false; }
    }

    void ChangeDirection()
    {
        direction = -direction;
        spriterenderer.flipX = !(spriterenderer.flipX);
    }
    public bool WaitForASecond()
    {
        float x = rigidbody2d.position.x;
        WaitOneSecond(x);
        return isChecked;
        
    }

    IEnumerator WaitOneSecond(float x)
    {

        yield return new WaitForSeconds(1f);
        Check2(x);
        

        // Code to execute after 1 second

    }
}