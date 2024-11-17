using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float maxHealth = 5f;
    private float currentHealth;
    public float transitionTime = 1f; // Время перехода
    private Color originalColor;
    private Color targetColor = Color.white;
    public SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Vector2 vector;

    public float CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            currentHealth = value;
        }
    }


    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        rb = GetComponent<Rigidbody2D>();

    }

    public void TakeDamage(float damage)
    {

        currentHealth -= damage;
        vector = new Vector2(rb.velocity.x * -3f, rb.velocity.y + 2f);
        rb.AddForce(vector * 15f);
        ChangeToTargetColor();

        // Проверка на смерть
        if (currentHealth <= 0)
        {
            Die();
        }
    }


    private void Die()
    {

        Destroy(gameObject);
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void ChangeToTargetColor()
    {
        StartCoroutine(TransitionToColor(targetColor));
    }

    IEnumerator TransitionToColor(Color target)
    {
        float startTime = Time.time;
        while (Time.time < startTime + transitionTime)
        {
            float progress = (Time.time - startTime) / transitionTime;
            spriteRenderer.color = Color.Lerp(originalColor, target, progress);
            yield return null;
        }
        spriteRenderer.color = target;  // Set to final color
    }
}