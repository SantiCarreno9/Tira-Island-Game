using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenuHandler : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject SettingsUI;
    public GameObject CreditsUI;
    public Image musicButton;
    public Sprite musicOn;
    public Sprite musicOff;
    public Image efectsButton;
    public Sprite efectsOn;
    public Sprite efectsOff;
    public Image GODModeButton;
    public Sprite ModeOn;
    public Sprite ModeOff;
    public Image NormalModeButton;
    private bool isMusicOn;
    private bool isEfectsOn;
    private bool isNormalModeOn;
    // Start is called before the first frame update
    void Start()
    {
        MainMenuUI.SetActive(true);
        SettingsUI.SetActive(false);
        CreditsUI.SetActive(false);
        isMusicOn = true;
        isEfectsOn = true;
        NormalModeButton.sprite = ModeOn;
        isNormalModeOn = true;
}

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NormalModeHandler()
    {
        if (isNormalModeOn)
        {
            NormalModeButton.sprite = ModeOff;
            GODModeButton.sprite = ModeOn;
            isNormalModeOn = false;
        }
        else
        {
            NormalModeButton.sprite = ModeOn;
            GODModeButton.sprite = ModeOff;
            isNormalModeOn = true;
        }
    }
    public void MusicButtonHandler()
    {
        if (isMusicOn)
        {
            musicButton.sprite = musicOff;
            isMusicOn = false;
        }
        else
        {
            musicButton.sprite = musicOn;
            isMusicOn = true;
        }
    }
    public void EfectsButtonHandler()
    {
        if (isEfectsOn)
        {
            efectsButton.sprite = efectsOff;
            isEfectsOn = false;
        }
        else
        {
            efectsButton.sprite = efectsOn;
            isEfectsOn = true;
        }
    }
    public void DisplayMainMenuUI()
    {
        MainMenuUI.SetActive(true);
    }
    public void CloseMainMenuUI()
    {
        MainMenuUI.SetActive(false);
    }
    public void DisplayMainSettingsUI()
    {
        SettingsUI.SetActive(true);
    }
    public void CloseMainSettingsUI()
    {
        SettingsUI.SetActive(false);
    }
    public void DisplayCreditsUI()
    {
        CreditsUI.SetActive(true);
    }
    public void CloseCreditsUI()
    {
        CreditsUI.SetActive(false);
    }
}
