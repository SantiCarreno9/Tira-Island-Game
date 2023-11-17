using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharSounds : MonoBehaviour
{
    public AudioSource stepSound;
    public AudioSource jumpSound;
    public AudioSource landSound;

    void playStep()
    {
        stepSound.Play();
    }
    void playJump()
    {
        jumpSound.Play();
    }

    void playLand()
    {
        landSound.Play();
    }

}
