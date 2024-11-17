using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        // Проверка на смерть
        if (currentHealth <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        // Вставка вашего кода для смерти персонажа (например, уничтожение объекта, анимация)
        Debug.Log("Персонаж погиб!");
        Destroy(gameObject); 
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }
}
