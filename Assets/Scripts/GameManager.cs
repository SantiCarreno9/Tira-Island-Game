using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private ScreenController _screenController = default;

    private void Start()
    {
        _screenController.ShowScreen(GameScreen.Start);
        _screenController.HideScreen(3);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public IEnumerator FinishAndRestartGame()
    {
        yield return new WaitForSeconds(1);
        _screenController.ShowScreen(GameScreen.Death, 1);
        yield return new WaitForSeconds(3);
        RestartGame();
    }
}
