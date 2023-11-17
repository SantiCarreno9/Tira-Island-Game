using UnityEngine;
using DG.Tweening;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private Ammo _ammoType = default;

    private void Start()
    {
        transform.DORotate(Vector3.up * 360, 2, RotateMode.FastBeyond360).SetLoops(-1);
    }

    private void OnDisable()
    {
        transform.DOKill();
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out WeaponsManager weaponsManager))
        {
            weaponsManager.SetAmmo(_ammoType);
            Destroy(gameObject);
        }
    }
}
