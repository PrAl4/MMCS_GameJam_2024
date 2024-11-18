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
    }

    void Update()

    {
        rigidbody2d.velocity = direction * speed;
        



    }
    void FixedUpdate()
    {
        StuckCheck(positionX);
        positionX = rigidbody2d.position.x;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(rigidbody2d.velocity.x);

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
                ChangeDirection();

            }
        }
    }
    void StuckCheck(float positionX)
    {
        if (rigidbody2d.position.x == positionX)
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        direction = -direction;
        spriterenderer.flipX = !(spriterenderer.flipX);
    }
}