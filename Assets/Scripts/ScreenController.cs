using UnityEngine;
using DG.Tweening;

public enum GameScreen
{
    Start,
    GameOver,
    Death
}

public class ScreenController : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup _screenCanvasGroup = default;

    [SerializeField]
    private GameObject _startScreen = default;
    [SerializeField]
    private GameObject _gameOverScreen = default;
    [SerializeField]
    private GameObject _deathScreen = default;

    public void ShowScreen(GameScreen screen, float fadeInDuration = 0)
    {
        _startScreen.SetActive(screen == GameScreen.GameOver);
        _gameOverScreen.SetActive(screen == GameScreen.GameOver);
        _deathScreen.SetActive(screen == GameScreen.Death);

        _screenCanvasGroup.gameObject.SetActive(true);
        _screenCanvasGroup.DOFade(1, fadeInDuration);
    }

    public void HideScreen(float duration = 0.5f)
    {
        _screenCanvasGroup.DOFade(0, duration).onComplete += () =>
        {
            _screenCanvasGroup.gameObject.SetActive(false);
        };
    }
}
