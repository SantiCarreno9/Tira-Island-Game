using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UIGameMenuHandler _gameMenuHandler = default;
    [SerializeField]
    private ScreenController _screenController = default;
    [SerializeField]
    private CharacterController _characterController = default;
    [SerializeField]
    private GameObject _enemiesContainer = default;

    public Action OnPlayerKilled = default;
    public Action<Vector2> OnCheckpointReached = default;

    private bool _isGamePaused = false;

    private void Start()
    {
        _screenController.ShowScreen(GameScreen.Start);
        _screenController.HideScreen(3);
        CheckMode();
    }    

    private void CheckMode()
    {
        _enemiesContainer.SetActive(!SettingsManager.GodModeOn);        
    }

    public void TakeCharacterTo(Vector2 position)
    {
        _characterController.transform.position = position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_isGamePaused) PauseGame();
            else ResumeGame();
        }
    }

    public void ResumeGame()
    {
        _isGamePaused = false;
        Time.timeScale = 1;
        _gameMenuHandler.ClosePauseMenuUI();
        _gameMenuHandler.ClosePauseSettingsMenuUI();
    }

    public void PauseGame()
    {
        _isGamePaused = true;
        Time.timeScale = 0;
        _gameMenuHandler.DisplayPauseMenuUI();
    }

    public void SaveUserInfo()
    {
        Vector2 position = _characterController.transform.position;
        OnCheckpointReached?.Invoke(position);
    }

    public void ShowDeathScreen()
    {
        OnPlayerKilled?.Invoke();
    }

    #region YOU ARE DEAD

    public void RestartLevelWithAnimation()
    {
        StartCoroutine(ShowDeadScreenAndRestartGame());
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public IEnumerator ShowDeadScreenAndRestartGame()
    {
        yield return new WaitForSeconds(1);
        _screenController.ShowScreen(GameScreen.Death, 1);
        yield return new WaitForSeconds(3);
        RestartGame();
    }

    #endregion

    #region GAME OVER

    public void EndGameWithAnimation()
    {
        StartCoroutine(ShowGameOverScreenAndEndGame());
    }

    public IEnumerator ShowGameOverScreenAndEndGame()
    {
        yield return new WaitForSeconds(1);
        _screenController.ShowScreen(GameScreen.GameOver, 1);
        yield return new WaitForSeconds(3);
        EndGame();
    }

    public void EndGame()
    {
        _gameMenuHandler.ChangeToMainMenu();
    }

    #endregion

    #region WIN

    public void WinGameWithAnimation()
    {
        StartCoroutine(ShowWinScreenAndEndGame());
    }

    public IEnumerator ShowWinScreenAndEndGame()
    {
        yield return new WaitForSeconds(2);
        _screenController.ShowScreen(GameScreen.Win, 1);
        yield return new WaitForSeconds(5);
        EndGame();
    }

    #endregion

}
