using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform trans;
    public Rigidbody2D body;

    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    private bool jumpInput;
    private bool isGrounded;
    private bool isClimbing;

    private float playerGravity = 7f;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.PlaySound("GameLoaded");

        trans = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isClimbing)
        {
            Walk();

            if (Input.GetKeyDown(KeyCode.W))
            {
                jumpInput = true;
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                jumpInput = false;
            }
        }
        if (isClimbing)
        {
            body.gravityScale = 0;
            body.drag = 50;
            ClimbMovement();
        }
        else
        {
            body.gravityScale = playerGravity;
            body.drag = 0;
        }
    }

    void FixedUpdate()
    {
        if (jumpInput && isGrounded)
        {
            Jump();
        }
    }

    void Walk()
    {
        if (Input.GetKey(KeyCode.A))
        {
            trans.position -= transform.right * Time.deltaTime * speed;
            trans.rotation = Quaternion.Euler(0, 0, 0);
            SoundManager.PlaySound("walkSound");
        }
        if (Input.GetKey(KeyCode.D))
        {
            trans.position -= transform.right * Time.deltaTime * speed;
            trans.rotation = Quaternion.Euler(0, 180, 0);
            SoundManager.PlaySound("walkSound");
        }
    }

    void Jump()
    {
        body.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
        SoundManager.PlaySound("jumpSound");
    }
    void ClimbMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            trans.position += transform.up * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            trans.position -= transform.up * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            trans.position += transform.right * Time.deltaTime * speed;
            trans.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            trans.position += transform.right * Time.deltaTime * speed;
            trans.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            for (int i = 0; i < collision.contacts.Length; i++)
            {
                if (collision.contacts[i].normal.y > 0.5)
                {
                    isGrounded = true;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isClimbing = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isClimbing = false;
        }
    }
    public float GetSpeed()
    {
        return speed;
    }
}
