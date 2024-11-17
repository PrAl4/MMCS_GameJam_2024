using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class YellowEnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Rigidbody2D rigidbody2d;
    private Vector2 direction = Vector2.left;
    private SpriteRenderer spriterenderer;
    private Health health;

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
    }

    void Update()

    {
        rigidbody2d.velocity = direction * speed;

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag != "Player")
        {
            ChangeDirection();
            
        }
        else
        {
            PlayerController weaponKey = collision.gameObject.GetComponent<PlayerController>();
            if (weaponKey.WeaponKey == 2){
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
}
