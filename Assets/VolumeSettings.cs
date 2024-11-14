using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    private void Start()
    {
        LoadVolume(); // Load and apply saved volume settings on game start
        ApplyVolumeToMixer(); // Apply settings directly to the mixer
    }

    public void SetMusicVoulume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVoulume()
    {
        float volume = SFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void LoadVolume()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        }
        else
        {
            musicSlider.value = 0.50f; // Default volume if no saved value
        }

        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        }
        else
        {
            SFXSlider.value = 0.75f; // Default volume if no saved value
        }
    }

    private void ApplyVolumeToMixer()
    {
        // Apply the saved or default slider values to the AudioMixer
        myMixer.SetFloat("Music", Mathf.Log10(musicSlider.value) * 20);
        myMixer.SetFloat("SFX", Mathf.Log10(SFXSlider.value) * 20);
    }
}

// public class VolumeSettings : MonoBehaviour
// {
//     [SerializeField] private AudioMixer myMixer;
//     [SerializeField] private Slider musicSlider;
//     [SerializeField] private Slider SFXSlider;

//     private void Start()
//     {
//         // if (PlayerPrefs.HasKey("musicVolume") || PlayerPrefs.HasKey("SFXVolume"))
//         // {
//             LoadVolume();
//         // }
//         // else
//         // {
//         //     SetMusicVoulume();
//         //     SetSFXVoulume();
//         // }
//     }

//     public void SetMusicVoulume()
//     {
//         float volume = musicSlider.value;
//         myMixer.SetFloat("Music", Mathf.Log10(volume)*20);
//         PlayerPrefs.SetFloat("musicVolume", volume);
//     }

//     public void SetSFXVoulume()
//     {
//         float volume = SFXSlider.value;
//         myMixer.SetFloat("SFX", Mathf.Log10(volume)*20);
//         PlayerPrefs.SetFloat("SFXVolume", volume);
//     }

//     public void LoadVolume()
//     {
//         musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
//         SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");

//         SetMusicVoulume();
//         SetSFXVoulume();
//     }
// }
