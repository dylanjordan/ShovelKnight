using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bugs : MonoBehaviour
{

    [SerializeField] float horizontalMoveSpeed;
    [SerializeField] GameObject currentCam;

    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCam.activeInHierarchy == true)
        {
            body.velocity = new Vector2(-horizontalMoveSpeed, body.velocity.y);
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
            Debug.Log("Welp");
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
}
