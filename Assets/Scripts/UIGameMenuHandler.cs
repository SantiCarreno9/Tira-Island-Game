using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGameMenuHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseMenuUI;
    [SerializeField]
    public GameObject _pauseSettingsMenuUI;

    [Space]
    [SerializeField]
    private Toggle _musicToggle;
    [SerializeField]
    private Toggle _soundEffectsToggle;

    [Space]
    [SerializeField]
    private TMP_Text _livesCountText = default;

    [Space]
    [SerializeField]
    private MusicManager _musicManager = default;
    [SerializeField]
    private SoundEffectsManager _soundEffectsManager = default;

    // Start is called before the first frame update
    void Start()
    {
        ClosePauseMenuUI();
        ClosePauseSettingsMenuUI();
        CheckSettings();
        CheckLives();
    }

    private void CheckSettings()
    {        
        _musicToggle.isOn=SettingsManager.MusicOn;
        _soundEffectsToggle.isOn=SettingsManager.SoundEffectsOn;        
    }

    private void CheckLives()
    {
        _livesCountText.text = GameInfoManager.Instance.Lives.ToString();
    }

    public void DisplayPauseMenuUI()
    {
        _pauseMenuUI.SetActive(true);
    }
    public void ClosePauseMenuUI()
    {
        _pauseMenuUI.SetActive(false);
    }
    public void DisplayPauseSettingsMenuUI()
    {
        _pauseSettingsMenuUI.SetActive(true);
    }
    public void ClosePauseSettingsMenuUI()
    {
        _pauseSettingsMenuUI.SetActive(false);
    }
    public void ChangeToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ToggleMusic(bool value)
    {
        SettingsManager.Instance.ToggleMusic(value);
        if (value) _musicManager.Unmute();
        else _musicManager.Mute();
    }

    public void ToggleSoundEffects(bool value)
    {
        SettingsManager.Instance.ToggleSoundEffects(value);
        if (value) _soundEffectsManager.Unmute();
        else _soundEffectsManager.Mute();
    }

}
