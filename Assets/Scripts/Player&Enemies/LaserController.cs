using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] int direction;
    private float speed = 5f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        
    }

    public void setDirection(int direction)
    {
        this.direction = direction;
        if (direction == -1)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = true;
        }
    }
   
    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x += direction * speed * Time.deltaTime;
        transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PurpleEnemy"))
        {
            other.gameObject.GetComponent<Health>().TakeDamage(1f);
        }
        if (!other.CompareTag("BraidHitArea") && !other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
