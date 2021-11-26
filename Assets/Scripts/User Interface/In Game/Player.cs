using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isAttacking;

    public int _maxHealth = 8;
    public int _currentHealth;

    public HealthBar healthBarUI;

    void Start()
    {
        _currentHealth = _maxHealth;
        healthBarUI.SetMaxHealth(_maxHealth);
    }

    void Update()
    {
        if (_currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        healthBarUI.SetHealth(_currentHealth);
    }
}
