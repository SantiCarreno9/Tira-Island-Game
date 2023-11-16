using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private Ammo _ammoType = default;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out WeaponsManager weaponsManager))
        {
            weaponsManager.SetAmmo(_ammoType);
            Destroy(gameObject);
        }
    }
}
