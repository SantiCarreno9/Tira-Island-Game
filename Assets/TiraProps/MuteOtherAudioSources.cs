using UnityEngine;

public class MuteOtherAudioSources : MonoBehaviour
{
    public AudioSource targetAudioSource;

    void Start()
    {
        // Mute all audio sources except the targetAudioSource
        MuteAllAudioSources();
    }

    void MuteAllAudioSources()
    {
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audioSource in allAudioSources)
        {
            if (audioSource != targetAudioSource)
            {
                audioSource.mute = true;
            }
        }
    }
}
