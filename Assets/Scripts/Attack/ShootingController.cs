using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField]
    private Projectile _projectile = default;
    [SerializeField]
    private Transform _shootingPoint = default;

    private Dictionary<string, Queue<Projectile>> _projectilePool = new Dictionary<string, Queue<Projectile>>();

    public void SetProjectile(Projectile projectile)
    {
        this._projectile = projectile;
    }

    public void Shoot()
    {
        Projectile instance = InstantiateProjectile(_projectile);
        instance.SetShootDirection(_shootingPoint.right);
    }

    private Projectile InstantiateProjectile(Projectile projectile)
    {
        string key = _projectile.name;
        Projectile item;

        if (!_projectilePool.ContainsKey(key))
            _projectilePool.Add(key, new Queue<Projectile>());

        if (_projectilePool[key].Count == 0)
        {
            item = Instantiate(_projectile);
            item.OnProjectileDeactivated += (item) =>
            {
                Debug.Log("Enqueued");
                _projectilePool[key].Enqueue(item);
            };
        }
        else item = _projectilePool[key].Dequeue();

        item.transform.position = _shootingPoint.position;
        item.transform.rotation = _shootingPoint.rotation;
        item.gameObject.SetActive(true);
        return item;
    }
}
