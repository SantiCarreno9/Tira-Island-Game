using UnityEngine;
using DG.Tweening;

public enum Screen
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

    public void ShowScreen(Screen screen, float fadeInDuration = 0.5f)
    {
        _startLevelScreen.SetActive(screen == Screen.Start);
        _finishLevelScreen.SetActive(screen == Screen.Finish);
        _deathScreen.SetActive(screen == Screen.Death);

        _screenCanvasGroup.gameObject.SetActive(true);          
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
            ShowScreen(Screen.Start);

        if (Input.GetKeyDown(KeyCode.T))
            HideScreen();
    }
}
