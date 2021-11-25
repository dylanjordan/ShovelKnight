using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerHitSound, inGameBackgroundSound, jumpSound, walkSound, playerDeath, dragonAttack, dragonDeath, bugDeath, dragonHurt, coinImpact;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        inGameBackgroundSound = Resources.Load<AudioClip>("Menu Sound #1");
        jumpSound = Resources.Load<AudioClip>("Jump");
        walkSound = Resources.Load<AudioClip>("Walking");
        playerHitSound = Resources.Load<AudioClip>("KnightHit");
        playerDeath = Resources.Load<AudioClip>("KnightDie");
        dragonAttack = Resources.Load<AudioClip>("dragon_attack");
        dragonDeath = Resources.Load<AudioClip>("dragon_death");
        bugDeath = Resources.Load<AudioClip>("bug_death");
        dragonHurt = Resources.Load<AudioClip>("dragon_hurt");
        coinImpact = Resources.Load<AudioClip>("Coin_impact");

        audioSrc = GetComponent<AudioSource>();
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
            case "dragonAttack":
                audioSrc.PlayOneShot(dragonAttack);
                break;
            case "dragonDeath":
                audioSrc.PlayOneShot(dragonDeath);
                break;
            case "bugDeath":
                audioSrc.PlayOneShot(bugDeath);
                break;
            case "dragonHurt":
                audioSrc.PlayOneShot(bugDeath);
                break;
            case "coinImpact":
                audioSrc.PlayOneShot(coinImpact);
                break;
        }
    }
}