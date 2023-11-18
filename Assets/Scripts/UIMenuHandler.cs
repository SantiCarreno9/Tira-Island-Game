using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenuHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainMenuUI;
    [SerializeField]
    private GameObject _settingsUI;
    [SerializeField]
    private GameObject _creditsUI;

    [Space]
    [SerializeField]
    private Toggle _musicToggle;
    [SerializeField]
    private Toggle _soundEffectsToggle;
    [SerializeField]
    private Toggle _godModeToggle;


    void Start()
    {
        DisplayMainMenuUI();
        CloseCreditsUI();
        CloseMainSettingsUI();
        CheckSettings();
    }

    private void CheckSettings()
    {
        _musicToggle.SetIsOnWithoutNotify(SettingsManager.MusicOn);
        _soundEffectsToggle.SetIsOnWithoutNotify(SettingsManager.SoundEffectsOn);
        _godModeToggle.SetIsOnWithoutNotify(SettingsManager.GodModeOn);
    }

    #region UI SWITCHING
    public void DisplayMainMenuUI()
    {
        _mainMenuUI.SetActive(true);
    }
    public void CloseMainMenuUI()
    {
        _mainMenuUI.SetActive(false);
    }
    public void DisplayMainSettingsUI()
    {
        _settingsUI.SetActive(true);
    }
    public void CloseMainSettingsUI()
    {
        _settingsUI.SetActive(false);
    }
    public void DisplayCreditsUI()
    {
        _creditsUI.SetActive(true);
    }
    public void CloseCreditsUI()
    {
        _creditsUI.SetActive(false);
    }
    #endregion

    #region FUNCTIONS

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ToggleMusic(bool value)
    {
        SettingsManager.Instance.ToggleMusic(value);
    }

    public void ToggleSoundEffects(bool value)
    {
        SettingsManager.Instance.ToggleSoundEffects(value);
    }

    public void ToggleGodMode(bool value)
    {
        SettingsManager.Instance.ToggleGodMode(value);
    }

    #endregion
}
