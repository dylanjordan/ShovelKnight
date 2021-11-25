using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D playerBody;

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
        playerBody = GetComponent<Rigidbody2D>();

        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
        if (_currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    private void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        healthBarUI.SetHealth(_currentHealth);
        if (_currentHealth > 0)
        {
            SoundManager.PlaySound("playerHit");
        }
        else
        {
            SoundManager.PlaySound("playerDeath");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dragon")
        {
            TakeDamage(2);
            playerBody.velocity = -playerBody.velocity * 0.5f;
        }

        if (collision.gameObject.tag == "Bug")
        {
            TakeDamage(1);
            playerBody.velocity = -playerBody.velocity * 0.5f;
        }
        if (collision.gameObject.tag == "Spike")
        {
            TakeDamage(8);
        }
    }
}
