using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    private int _dragonMaxHealth = 16;
    private int _dragonCurrentHealth;

    public HealthBar DragonHealthUI;
    void Start()
    {
        _dragonCurrentHealth = _dragonMaxHealth;
        DragonHealthUI.SetMaxHealth(_dragonMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (_dragonCurrentHealth == 0)
        {
            Destroy(gameObject);
            SoundManager.PlaySound("dragonDeath");
        }
    }

    public void DragonDamage(int damage)
    {
        _dragonCurrentHealth -= damage;
        DragonHealthUI.SetHealth(_dragonCurrentHealth);
        SoundManager.PlaySound("dragonHurt");

        //if(_dragonCurrentHealth > 0)
        //{

        //}
        //else
        //{

        //}
    }
}