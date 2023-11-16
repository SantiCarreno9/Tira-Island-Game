using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfoManager : MonoBehaviour
{
    public static GameInfoManager Instance;
    private Vector3 _playerPosition = Vector3.zero;
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

    private void OnEnable()
    {
        FindObjectOfType<GameManager>().OnPlayerKilled += SaveUserInfo;
    }

    private void SaveUserInfo()
    {
        _lives = 0;
        FindObjectOfType<GameManager>().OnPlayerKilled -= SaveUserInfo;
        FindObjectOfType<GameManager>().OnPlayerKilled -= SaveUserInfo;
        FindObjectOfType<GameManager>().OnPlayerKilled -= SaveUserInfo;
        FindObjectOfType<GameManager>().OnPlayerKilled -= SaveUserInfo;
    }
}
