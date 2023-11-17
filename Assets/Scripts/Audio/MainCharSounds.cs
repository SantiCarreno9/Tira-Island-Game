using UnityEngine;

public class MainCharSounds : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip stepSound;
    public AudioClip jumpSound;
    public AudioClip landSound;
    public AudioClip shootSound;

    void playStep()
    {
        audioSource.clip = stepSound;
        audioSource.Play();
    }
    void playJump()
    {
        audioSource.clip = jumpSound;
        audioSource.Play();
    }

    void playLand()
    {
        audioSource.clip = landSound;
        audioSource.Play();
    }

    void playShoot()
    {
        audioSource.clip = shootSound;
        audioSource.Play();
    }
}
