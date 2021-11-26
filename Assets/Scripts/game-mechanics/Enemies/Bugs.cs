using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bugs : MonoBehaviour
{

    [SerializeField] float Speed;
    [SerializeField] GameObject currentCam;

    public int _bugMaxHealth = 2;
    public int _bugCurrentHealth;

    Rigidbody2D body;
    Transform bugTrans;

    // Start is called before the first frame update
    void Start()
    {
        _bugCurrentHealth = _bugMaxHealth;

        bugTrans = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        BugDirection();

        if (currentCam.activeInHierarchy == true)
        {
            body.velocity = new Vector2(Speed, body.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            body.velocity = new Vector2(0, body.velocity.y);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        body.velocity = new Vector2(0, body.velocity.y);
    }
}

        if (_bugCurrentHealth == 0)
        {
            Destroy(gameObject);
            SoundManager.PlaySound("bugDeath");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Speed = Speed * -1; 
        }
    }
    void BugDirection()
    {
        if (Speed < 0)
        {
            bugTrans.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Speed > 0)
        {
            bugTrans.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    public void BugDamage(int damage)
    {
        _bugCurrentHealth -= damage;

        //if (_bugcurrentHealth > 0)
        //{

        //}
        //else
        //{

        //}
    }
}
