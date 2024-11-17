using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallController : MonoBehaviour
{
    [SerializeField] int direction;
    private float speed = 5f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {

    }

    public void setDirection(int direction)
    {
        Debug.Log(direction);
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
        if (other.CompareTag("BlueEnemy"))
        {
            // ��� ���� �� Blue Enemy
        }
        if (!other.CompareTag("BraidHitArea") && !other.CompareTag("Player"))
        {
            Debug.Log(other.gameObject);
            Destroy(gameObject);
        }
    }

}
