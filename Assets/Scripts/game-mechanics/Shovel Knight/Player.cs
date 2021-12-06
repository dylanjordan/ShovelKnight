using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Attack attack;
    public Rigidbody2D playerBody;

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

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    public void TakeDamage(int damage)
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
        }
        if (collision.gameObject.tag == "Bug")
        {
           TakeDamage(1);
        }
        if (collision.gameObject.tag == "Spike")
        {
           TakeDamage(8);
        }
        if (collision.gameObject.tag == "fireball")
        {
            TakeDamage(3);
        }
        if (collision.collider.tag == "dirtblock")
        {
            Destroy(collision.gameObject);
        }
    }
}
