using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Image _ammoImage = default;
    [SerializeField]
    private TMP_Text _ammoCount = default;
    [SerializeField]
    private GameObject _infinitySymbol = default;

    [Space]
    [Header("Sprites")]
    [SerializeField]
    private Sprite _shotgunAmmoSprite = default;
    [SerializeField]
    private Sprite _rocketAmmoSprite = default;
    [SerializeField]
    private Sprite _grenadeSprite = default;


    public void ChangeAmmoSprite(Ammo ammo)
    {
        switch (ammo)
        {
            case Ammo.Shotgun:
                _ammoImage.sprite = _shotgunAmmoSprite;
                break;
            case Ammo.Rocket:
                _ammoImage.sprite = _rocketAmmoSprite;
                break;
            case Ammo.Grenade:
                _ammoImage.sprite = _grenadeSprite;
                break;
            default:
                break;
        }
    }

    public void UpdateAmmoCount(int count)
    {
        _infinitySymbol.SetActive(count < 0);
        _ammoCount.text = count < 0 ? "" : "x" + count.ToString();
    }

}
