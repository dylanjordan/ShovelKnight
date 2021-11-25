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
}
