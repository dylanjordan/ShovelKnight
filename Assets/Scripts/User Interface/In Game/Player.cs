using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 8;
    public int currentHealth;

    public HealthBar healthBarUI;

    void Start()
    {
        currentHealth = maxHealth;
        healthBarUI.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
        if (currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBarUI.SetHealth(currentHealth);
    }
}
