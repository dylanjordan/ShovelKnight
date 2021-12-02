using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bugs : MonoBehaviour
{

    [SerializeField] float Speed;
    [SerializeField] GameObject currentCam;

    Rigidbody2D body;
    Transform bugTrans;

    // Start is called before the first frame update
    void Start()
    {

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

        if (collision.collider.tag == "Weapon")
        {
            Destroy(gameObject);
            SoundManager.PlaySound("bugDeath");
        }

        if (collision.gameObject.tag == "Wall")
        {
            Speed = Speed * -1;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            body.velocity = new Vector2(0, body.velocity.y);
        }

        if (collision.collider.tag == "Weapon")
        {
            body.AddForce(transform.up * 10, ForceMode2D.Impulse);
            body.AddForce(transform.right * 10, ForceMode2D.Impulse);
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
}
