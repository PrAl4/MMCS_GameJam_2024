using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraidAreaTrigger : MonoBehaviour
{
    private PolygonCollider2D hit_area;
    private List<GameObject> enemyTriggers;
    private bool currentFlip = false;
    void Start()
    {
        enemyTriggers = new List<GameObject>();
        hit_area = GetComponent<PolygonCollider2D>();
    }
    public void FlipHitArea(bool flip)
    {
        if (currentFlip != flip)
        {
            currentFlip = flip;
            Vector2[] points = hit_area.points;
            for (int i = 0; i < points.Length; i++)
            {
                points[i].x = -points[i].x;
            }
            hit_area.points = points;
        }
    }
    public List<GameObject> GetTriggers()
    {
        return enemyTriggers;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RedEnemy"))
        {
            enemyTriggers.Add(other.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("RedEnemy"))
        {
            enemyTriggers.Remove(other.gameObject);
        }
    }
}
