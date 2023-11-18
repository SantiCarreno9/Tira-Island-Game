using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] _audioSources = default;

    public void Mute()
    {
        for (int i = 0; i < _audioSources.Length; i++)        
            _audioSources[i].mute = true;        
    }

    public void Unmute()
    {
        for (int i = 0; i < _audioSources.Length; i++)
            _audioSources[i].mute = false;
    }
}
