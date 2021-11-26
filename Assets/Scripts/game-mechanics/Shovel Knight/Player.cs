using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D playerBody;
    
    Dragon dragon;
    Bugs bug;

    public int _maxHealth = 8;
    public int _currentHealth;

    private bool isAttacking;

    public HealthBar healthBarUI;

    void Start()
    {
        _currentHealth = _maxHealth;
        healthBarUI.SetMaxHealth(_maxHealth);
    }

    void Update()
    {
        playerBody = GetComponent<Rigidbody2D>();

        if (_currentHealth == 0)
        {
            Destroy(gameObject);
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
    public void Attacking()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dragon" && !isAttacking)
        {
            TakeDamage(2);
            playerBody.velocity = -playerBody.velocity * 0.5f;
        }
        if (collision.gameObject.tag == "Dragon" && isAttacking)
        {
            dragon.DragonDamage(2);
        }
        if (collision.gameObject.tag == "Bug" && !isAttacking)
        {
           TakeDamage(1);
        playerBody.velocity = -playerBody.velocity * 0.5f;
        }
        if (collision.gameObject.tag == "Bug" && isAttacking)
        {
            bug.BugDamage(2);
        }
        if (collision.gameObject.tag == "Spike")
        {
           TakeDamage(8);
        }
    }
}
