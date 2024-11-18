using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RedEnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float leftCorner, rightCorner;
    private Rigidbody2D rigidbody2d;
    private Vector2 direction = Vector2.left;
    private int _direction = 1;
    private SpriteRenderer spriterenderer;
    private Health health;
    private float positionX;
 


    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        spriterenderer.flipX = false;
        health = GetComponent<Health>();
        
       

    }
    void Start()
    {
        rigidbody2d.velocity = direction * speed *_direction;
        positionX = rigidbody2d.position.x;
        Debug.Log(positionX);


    }

    void FixedUpdate()

    {
        rigidbody2d.velocity = direction * speed * _direction;
        Debug.Log(positionX);


        if (rigidbody2d.position.x < positionX - leftCorner )
        {
            _direction = -1;
            spriterenderer.flipX = true;

        }
        if (rigidbody2d.position.x > positionX + rightCorner)
        {
            _direction = 1;
            spriterenderer.flipX = false;



        }

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
        
    }
   
    

    void ChangeDirection()
    {
        direction = -direction;
        spriterenderer.flipX = !(spriterenderer.flipX);
    }
    IEnumerator WaitOneSecond()
    {
        yield return new WaitForSeconds(3f);
        // Code to execute after 1 second
        Debug.Log("One second has passed!");
    }

}