using UnityEngine;
using DG.Tweening;

public enum GameScreen
{
    Start,
    Finish,
    Death
}

public class ScreenController : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup _screenCanvasGroup = default;

    [SerializeField]
    private GameObject _startLevelScreen = default;
    [SerializeField]
    private GameObject _finishLevelScreen = default;
    [SerializeField]
    private GameObject _deathScreen = default;

    public void ShowScreen(GameScreen screen, float fadeInDuration = 0)
    {
        _startLevelScreen.SetActive(screen == GameScreen.Start);
        _finishLevelScreen.SetActive(screen == GameScreen.Finish);
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ShowScreen(GameScreen.Start);

        if (Input.GetKeyDown(KeyCode.T))
            HideScreen();
    }
}
