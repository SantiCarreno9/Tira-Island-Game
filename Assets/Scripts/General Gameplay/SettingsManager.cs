using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    public static bool MusicOn { get; private set; } = true;
    public static bool SoundEffectsOn { get; private set; } = true;
    public static bool GodModeOn { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void ToggleMusic(bool value)
    {
        MusicOn = value;
    }

    public void ToggleSoundEffects(bool value)
    {
        SoundEffectsOn = value;
    }

    public void ToggleGodMode(bool value)
    {
        GodModeOn = value;
    }
}
