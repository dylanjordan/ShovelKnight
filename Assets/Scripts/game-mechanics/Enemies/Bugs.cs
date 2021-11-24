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
}
