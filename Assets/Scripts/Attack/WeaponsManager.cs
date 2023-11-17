using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Ammo
{
    Shotgun,
    Rocket,
    Grenade
}

public class WeaponsManager : MonoBehaviour
{
    [SerializeField]
    private ShootingController _shootingController = default;

    [Space]
    [SerializeField]
    private Projectile _shotgun = default;
    [SerializeField]
    private Projectile _rocket = default;
    [SerializeField]
    private Projectile _grenade = default;
    [SerializeField]
    private Ammo _currentAmmo = Ammo.Shotgun;

    [Space]
    public UnityEvent<Ammo> OnAmmoChanged = default;
    public UnityEvent<int> OnAmmoCountChanged = default;

    private List<Projectile> _shootgunPool = new List<Projectile>();
    private List<Projectile> _rocketsPool = new List<Projectile>();
    private List<Projectile> _grenadePool = new List<Projectile>();

    private int _amount = 0;

    private void Start()
    {
        SetAmmo(_currentAmmo);
    }

    public void SetAmmo(Ammo ammo)
    {
        int amount = 0;
        switch (ammo)
        {
            case Ammo.Shotgun:
                _shootingController.SetProjectile(_shotgun);
                amount = -1;
                break;
            case Ammo.Rocket:
                _shootingController.SetProjectile(_rocket);
                amount = 10;
                break;
            case Ammo.Grenade:
                _shootingController.SetProjectile(_grenade);
                amount = 10;
                break;
            default:
                break;
        }
        if (_currentAmmo == ammo)
            _amount += amount;
        else _amount = amount;

        _currentAmmo = ammo;
        OnAmmoChanged?.Invoke(_currentAmmo);
        OnAmmoCountChanged?.Invoke(_amount);
    }

    public void OnShoot()
    {
        if (_currentAmmo == Ammo.Shotgun)
            return;
        _amount--;
        OnAmmoCountChanged?.Invoke(_amount);
        if (_amount == 0)
            SetAmmo(Ammo.Shotgun);

    }
}
