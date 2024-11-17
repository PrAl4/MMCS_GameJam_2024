using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RedEnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Rigidbody2D rigidbody2d;
    private Vector2 direction = Vector2.left;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
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
        if (collision.gameObject.tag == "Player")
        {

            Destroy(collision.gameObject);
        }
    }

    void ChangeDirection()
    {
        rigidbody2d.velocity = -speed*direction ;
    }
}
