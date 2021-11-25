using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;


    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("Menu Sound #1"))
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
    
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Menu Sound #1");

    }

    private void Save()
    {
        PlayerPrefs.SetFloat("Menu Sound #1", volumeSlider.value);

    }
}
