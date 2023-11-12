using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuHandler : MonoBehaviour
{
    public string mainMenu = "Main Menu";
    public string settingsMenu = "Settings Menu";
    public string mainSettingsMenu = "Main Settings Menu";
    public string pauseMenu = "Pause Menu";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeToMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
    public void ChangeToSettingsMenu()
    {
        SceneManager.LoadScene(settingsMenu);
    }
    public void ChangeToMainSettingsMenu()
    {
        SceneManager.LoadScene(mainSettingsMenu);
    }
    public void ChangeToPauseMenu()
    {
        SceneManager.LoadScene(pauseMenu);
    }
}
