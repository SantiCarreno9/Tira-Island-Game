using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGameMenuHandler : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public GameObject PauseSettingsMenuUI;
    public string mainMenu = "Main Menu";
    public string mainSettingsMenu = "Main Settings Menu";
    public Image musicButton;
    public Sprite musicOn;
    public Sprite musicOff;
    public Image efectsButton;
    public Sprite efectsOn;
    public Sprite efectsOff;
    private bool isMusicOn;
    private bool isEfectsOn;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenuUI.SetActive(false);
        PauseSettingsMenuUI.SetActive(false);
        isMusicOn = true;
        isEfectsOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
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
    public void DisplayPauseMenuUI()
    {
        PauseMenuUI.SetActive(true);
    }
    public void ClosePauseMenuUi()
    {
        PauseMenuUI.SetActive(false);
    }
    public void DisplayPauseSettingsMenuUI()
    {
        PauseSettingsMenuUI.SetActive(true);
    }
    public void ClosePauseSettingsMenuUI()
    {
        PauseSettingsMenuUI.SetActive(false);
    }
    public void ChangeToMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
    public void ChangeToMainSettingsMenu()
    {
        SceneManager.LoadScene(mainSettingsMenu);
    }

}
