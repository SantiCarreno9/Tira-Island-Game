using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField]
    private Projectile _projectile = default;
    [SerializeField]
    private Transform _shootingPoint = default;

    public void SetProjectile(Projectile projectile)
    {
        this._projectile = projectile;
    }

    public void Shoot()
    {
        if (!enabled)
            return;
        Projectile instance = Instantiate(_projectile, _shootingPoint.transform.position, _shootingPoint.rotation);
        instance.SetShootDirection(_shootingPoint.right);
    }
}
