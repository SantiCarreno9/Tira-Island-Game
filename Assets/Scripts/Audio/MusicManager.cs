using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;

    public void Mute()
    {
        _audioSource.mute = true;
    }

    public void Unmute()
    {
        _audioSource.mute = false;
    }
}
