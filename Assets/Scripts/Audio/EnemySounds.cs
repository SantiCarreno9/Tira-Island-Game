using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip stepSound;
    public AudioClip jumpSound;
    public AudioClip landSound;
    public AudioClip shootSound;

    public float maxVolumeDistance = 10f;
    public float minVolumeDistance = 2f;

    void Update()
    {
        float distanceX = Mathf.Abs(transform.position.x - Camera.main.transform.position.x);
        float volume = Mathf.Clamp01(1f - (distanceX - minVolumeDistance) / (maxVolumeDistance - minVolumeDistance));
        audioSource.volume = volume;
    }
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
