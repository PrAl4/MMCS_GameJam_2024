using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RedEnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Rigidbody2D rigidbody2d;
    private Vector2 direction = Vector2.left;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

    }

    void Start()
    {
        rigidbody2d.velocity = direction * speed;
    }

    void Update()

    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
    }
}
