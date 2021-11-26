using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    public static AudioClip playerHitSound, jumpSound, walkSound, playerDeath, dragonAttack, dragonDeath, bugDeath, dragonHurt, coinImpact, dirtBreak, playerAttack;
    static AudioSource audioSrc;
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("Jump");
        walkSound = Resources.Load<AudioClip>("Walking");
        playerHitSound = Resources.Load<AudioClip>("KnightHit");
        playerDeath = Resources.Load<AudioClip>("KnightDie");
        dragonAttack = Resources.Load<AudioClip>("dragon_attack");
        dragonDeath = Resources.Load<AudioClip>("dragon_death");
        bugDeath = Resources.Load<AudioClip>("bug_death");
        dragonHurt = Resources.Load<AudioClip>("dragon_hurt");
        coinImpact = Resources.Load<AudioClip>("Coin_impact");
        dirtBreak = Resources.Load<AudioClip>("dirt_break");
        playerAttack = Resources.Load<AudioClip>("KnightAttack");

        audioSrc = GetComponent<AudioSource>();

        if (!PlayerPrefs.HasKey("Menu Sound #1"))
        {
            PlayerPrefs.SetFloat("Menu Sound #1", 1);
        }
        else
        {
            Load();
        }
    }
    public void ChangeVolume()
    {
        // volume is same as the slider percentage
        AudioListener.volume = volumeSlider.value;
        Save();
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
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
            case "dirtBreak":
                audioSrc.PlayOneShot(dirtBreak);
                break;
            case "playerAttack":
                audioSrc.PlayOneShot(playerAttack);
                break;
        }
    }
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Menu Sound #1");

    }
    private void Save()
    {
        PlayerPrefs.SetFloat("Menu Sound #1", volumeSlider.value);

    }
}