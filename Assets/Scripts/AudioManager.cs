using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header ("---------- Audio Source ----------") ]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip background;
    public AudioClip footsteps;
    public AudioClip jump;
    public AudioClip pickheart;
    public AudioClip pickkey;
    public AudioClip damage;
    public AudioClip win;
    public AudioClip lose;
    //public AudioClip damage;

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
