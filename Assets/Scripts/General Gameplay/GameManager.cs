using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]
    private ScreenController _screenController = default;
    private CharacterController _characterController = default;

    public CharacterController Character => _characterController;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void OnEnable()
    {
        if (_characterController == null)
            _characterController = FindObjectOfType<CharacterController>();

        _characterController.GetComponent<Health>().OnZeroHealth.AddListener(OnPlayerKilled);
        _screenController.ShowScreen(GameScreen.Start);
        _screenController.HideScreen(3);
    }

    private void OnDisable()
    {
        if (_characterController == null)
            _characterController = FindObjectOfType<CharacterController>();
        _characterController.GetComponent<Health>().OnZeroHealth.RemoveListener(OnPlayerKilled);
    }

    private void OnPlayerKilled()
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
        yield return new WaitForSeconds(1);
        _screenController.ShowScreen(GameScreen.Death, 1);
        yield return new WaitForSeconds(3);
        RestartGame();
    }
}
