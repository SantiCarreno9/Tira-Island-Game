using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private ScreenController _screenController = default;
    [SerializeField]
    private CharacterController _characterController = default;

    public Action OnPlayerKilled = default;
    public Action<Vector2> OnCheckpointReached = default;

    private bool _isPlayerStopped = false;

    private void OnEnable()
    {
        if (_characterController != null)
            _characterController.GetComponent<Health>().OnZeroHealth.AddListener(ShowDeathScreen);
        _screenController.ShowScreen(GameScreen.Start);
        _screenController.HideScreen(3);
    }

    public void TakeCharacterTo(Vector2 position)
    {
        _characterController.transform.position = position;
    }

    private void OnDisable()
    {
        if (_characterController != null)
            _characterController.GetComponent<Health>().OnZeroHealth.RemoveListener(ShowDeathScreen);
    }

    public void SaveUserInfo()
    {
        Vector2 position = _characterController.transform.position;
        OnCheckpointReached?.Invoke(position);
    }

    private void ShowDeathScreen()
    {
        OnPlayerKilled?.Invoke();
    }

    public void RestartLevel()
    {
        StartCoroutine(FinishAndRestartGame());
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public IEnumerator FinishAndRestartGame()
    {
        OnPlayerKilled?.Invoke();
        yield return new WaitForSeconds(1);
        _screenController.ShowScreen(GameScreen.Death, 1);
        yield return new WaitForSeconds(3);
        RestartGame();
    }
}
