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

    public CharacterController Character => _characterController;
    public Action OnPlayerKilled = default;    

    private void OnEnable()
    {
        _characterController.GetComponent<Health>().OnZeroHealth.AddListener(RestartLevel);
        _screenController.ShowScreen(GameScreen.Start);
        _screenController.HideScreen(3);
    }

    private void OnDisable()
    {
        _characterController.GetComponent<Health>().OnZeroHealth.RemoveListener(RestartLevel);
    }

    private void RestartLevel()
    {
        StartCoroutine(FinishAndRestartGame());
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
    }

    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
        _screenController.HideScreen(0);
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
