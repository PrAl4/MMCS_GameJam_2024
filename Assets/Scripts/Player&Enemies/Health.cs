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

        // �������� �� ������
        if (currentHealth <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        // ������� ������ ���� ��� ������ ��������� (��������, ����������� �������, ��������)
        Debug.Log("�������� �����!");
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
