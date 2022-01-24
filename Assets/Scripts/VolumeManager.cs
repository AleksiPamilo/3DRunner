using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolumeManager : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        // Tarkistetaan onko ‰‰nenvoimakkuus tallennettuna
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            // Jos dataa ei ole tallennettu, asetetaan ‰‰nenvoimakkuudeksi 100%
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void SetVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        // Haetaan data PlayerPrefs luokasta
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        // Tallennetaan data PlayerPrefs luokkaan
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
