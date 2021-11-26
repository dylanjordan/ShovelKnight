using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    [SerializeField] Transform playerTrans;
    [SerializeField] GameObject fireballPrefab;
    [SerializeField] GameObject currentCam;
    [SerializeField] float fireballSpeed;

    float timeToNextAttack = 0;

    bool initalDelayApplied;

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
            SceneManager.LoadScene("Winner");
        }
        if ((currentCam.activeInHierarchy == true))
        {
            if (canAttack())
            {
                Attack();
            }

            if (!initalDelayApplied)
            {
                timeToNextAttack = Time.realtimeSinceStartup + 0.5f;
                initalDelayApplied = true;
            }
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
    void Attack()
    {
        var fireball = Instantiate(fireballPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));

        fireball.GetComponent<Rigidbody2D>().velocity = (playerTrans.position - transform.position).normalized * fireballSpeed;

        Destroy(fireball, 5);
    }

    bool canAttack()
    {
        if (timeToNextAttack < Time.realtimeSinceStartup)
        {
            timeToNextAttack = Time.realtimeSinceStartup + 3f;
            return true;
        }
        else
        {
            return false;
        }
    }

}