using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{

    Animator anim;

    [SerializeField] Attack attack;
    PlayerController playerMovement;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
         player = GetComponent<Player>();
        anim = GetComponent<Animator>();
        attack = GetComponent<Attack>();
        playerMovement = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.GetIsWalking())
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        if (playerMovement.GetIsGrounded())
        {
            anim.SetBool("InAir", false);
        }
        else
        {
            anim.SetBool("InAir", true);
        }

        if (playerMovement.GetIsClimbing())
        {
            anim.SetBool("Climbing", true);
        }
        else
        {
            anim.SetBool("Climbing", false);
        }

        if (attack.GetIsAttacking())
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    }
}
