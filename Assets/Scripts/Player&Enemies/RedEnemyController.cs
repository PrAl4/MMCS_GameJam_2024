using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RedEnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float leftCorner, rightCorner;
    //[SerializeField] int _numberOfScene;

    private Rigidbody2D rigidbody2d;
    private Vector2 direction = Vector2.left;
    private int _direction = 1;
    private SpriteRenderer spriterenderer;
    private Health health;
    private float positionX;

    public static event Action diePlayer;

    GameDataScript gameData;

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
        gameData = GettingGameData.GetDataObj();

    }

    void FixedUpdate()

    {
        rigidbody2d.velocity = direction * speed * _direction;


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
            if ((int)gameData.curGunMode == 2)
            {
                health.TakeDamage(1f);
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
    }

}