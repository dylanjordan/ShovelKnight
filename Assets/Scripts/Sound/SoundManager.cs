using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerHitSound, inGameBackgroundSound, jumpSound, walkSound, playerDeath;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        inGameBackgroundSound = Resources.Load<AudioClip>("Menu Sound #1");
        jumpSound = Resources.Load<AudioClip>("Jump");
        walkSound = Resources.Load<AudioClip>("Walking");
        playerHitSound = Resources.Load<AudioClip>("KnightHit");
        playerDeath = Resources.Load<AudioClip>("KnightDie");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "GameLoaded":
                audioSrc.PlayOneShot(inGameBackgroundSound);
                break;
            case "jumpSound":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "playerHit":
                audioSrc.PlayOneShot(playerHitSound);
                break;
            case "playerDeath":
                audioSrc.PlayOneShot(playerDeath);
                break;
        }
    }
}