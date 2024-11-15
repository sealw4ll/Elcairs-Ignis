using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------Audio Source----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------Audio Clip------------")]
    public AudioClip background; // 
    public AudioClip sword_swing; //
    public AudioClip projectile_clash; //
    public AudioClip get_hit; 
    public AudioClip dash; //
    public AudioClip jump; //
    public AudioClip land; //
    public AudioClip air_jump; //
    public AudioClip footsteps;
    public AudioClip enemy_die; //
    public AudioClip player_die; //
    public AudioClip player_die_lava; //
    public AudioClip enemy_shot; // 

    public static AudioManager instance;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
