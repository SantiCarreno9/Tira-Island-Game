using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody = default;
    [SerializeField]
    private GameObject _normalState = default;
    [SerializeField]
    private GameObject _collisionState = default;

    [Space]
    [SerializeField]
    private int _speed = 100;
    [SerializeField]
    private int _damagePoints = 25;
    [SerializeField]
    private float _duration = 3;

    private Vector3 _shootDirection = Vector3.zero;
    private bool _move = true;

    private void Start()
    {
        Invoke("DestroyProjectile", _duration);
    }

    public void SetShootDirection(Vector3 direction)
    {
        _shootDirection = direction;
    }

    private void Update()
    {
        if (_move)
            transform.position += _shootDirection * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health health))
            health.DecreaseHealthBy(_damagePoints);

        DestroyProjectile();
    }

    private void DestroyProjectile()
    {
        _move = false;
        if (_collisionState != null)
        {
            if (_normalState != null) _normalState.gameObject.SetActive(false);
            _collisionState.gameObject.SetActive(true);
        }
        Destroy(gameObject, 0.5f);
    }
}
