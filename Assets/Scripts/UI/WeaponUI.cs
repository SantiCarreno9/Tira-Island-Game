using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private TMP_Text _ammoCount = default;
    [SerializeField]
    private GameObject _infinitySymbol = default;

    [Space]
    [Header("Sprites")]
    [SerializeField]
    private GameObject _shotgunBulletImage = default;
    [SerializeField]
    private GameObject _rocketImage = default;
    [SerializeField]
    private GameObject _grenadeImage = default;


    public void ChangeAmmoSprite(Ammo ammo)
    {
        _shotgunBulletImage.SetActive(ammo == Ammo.Shotgun);
        _rocketImage.SetActive(ammo == Ammo.Rocket);
        _grenadeImage.SetActive(ammo == Ammo.Grenade);
    }

    public void UpdateAmmoCount(int count)
    {
        _infinitySymbol.SetActive(count < 0);
        _ammoCount.text = count < 0 ? "" : count.ToString();
    }

}
