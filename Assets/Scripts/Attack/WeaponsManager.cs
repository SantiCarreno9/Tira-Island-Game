using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Ammo
{
    Shotgun,
    FlameThrower,
    Rocket,
    Grenade
}

public class WeaponsManager : MonoBehaviour
{
    [Header("Types of attacks")]
    [SerializeField]
    private ShootingController _shootingController = default;
    [SerializeField]
    private CloseRangeAttackController _closeRangeController = default;

    [Space]
    [Header("Close Range")]
    [SerializeField]
    private GameObject _shotgunAmmo = default;
    [SerializeField]
    private GameObject _flameThrowerAmmo = default;

    [Header("Projectiles")]
    [SerializeField]
    private Projectile _rocket = default;
    [SerializeField]
    private Projectile _grenade = default;

    private Ammo _currentAmmo = Ammo.Shotgun;
    private int _amount = -1;

    private void Start()
    {
        SetAmmo(Ammo.Shotgun);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
            SetAmmo(Ammo.Shotgun);
        if (Input.GetKeyDown(KeyCode.B))
            SetAmmo(Ammo.Rocket);
    }

    public void SetAmmo(Ammo ammo)
    {
        _currentAmmo = ammo;
        switch (ammo)
        {
            case Ammo.Shotgun:
                _shootingController.enabled = false;
                _closeRangeController.enabled = true;
                _shotgunAmmo.SetActive(true);
                _flameThrowerAmmo.SetActive(false);
                break;
            case Ammo.FlameThrower:
                _shootingController.enabled = false;
                _closeRangeController.enabled = true;
                _shotgunAmmo.SetActive(false);
                _flameThrowerAmmo.SetActive(true);
                break;
            case Ammo.Rocket:
                _shootingController.enabled = true;
                _closeRangeController.enabled = false;
                _shootingController.SetProjectile(_rocket);
                break;
            case Ammo.Grenade:
                _shootingController.enabled = true;
                _closeRangeController.enabled = false;
                _shootingController.SetProjectile(_grenade);
                break;
            default:
                break;
        }

    }
}
