using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInfoManager : MonoBehaviour
{
    public static GameInfoManager Instance;

    private GameManager _gameManager = default;
    private const int INITIAL_LIVES_COUNT = 3;

    private bool _hasSavedPlayerInfo = false;
    private Vector2 _playerPosition = Vector2.zero;
    private int _lives = 3;
    private Ammo _currentAmmo;
    private int _currentAmmoCount = 0;

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

    private void Start()
    {
        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
    }

    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
        OnEnable();
    }

    private void OnEnable()
    {
        _gameManager = FindObjectOfType<GameManager>();
        if (_gameManager != null)
        {
            _gameManager.OnPlayerKilled += UpdateLivesCount;
            _gameManager.OnCheckpointReached += SaveUserInfo;
            if (_hasSavedPlayerInfo)
                _gameManager.TakeCharacterTo(_playerPosition);
        }
    }

    private void OnDisable()
    {
        if (_gameManager != null)
        {
            _gameManager.OnPlayerKilled -= UpdateLivesCount;
            _gameManager.OnCheckpointReached -= SaveUserInfo;
        }
    }

    private void SaveUserInfo(Vector2 position)
    {
        _playerPosition = position;
        _hasSavedPlayerInfo = true;
    }

    private void UpdateLivesCount()
    {
        _lives--;

        if (_gameManager != null)
        {
            _gameManager.OnPlayerKilled -= UpdateLivesCount;
            if (_lives > 0)
                _gameManager.RestartLevel();
        }
    }
}
