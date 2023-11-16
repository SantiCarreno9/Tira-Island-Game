using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private Collider2D _mainCollider = default;
    [SerializeField]
    private Rigidbody2D _rigidbody = default;
    [SerializeField]
    private Damage _damage = default;

    [Space]
    [SerializeField]
    private GameObject _normalState = default;
    [SerializeField]
    private GameObject _collisionState = default;

    [Space]
    [SerializeField]
    protected int speed = 10;
    [SerializeField]
    private float _duration = 3;
    [SerializeField]
    private float _destructionTime = 0.5f;

    [SerializeField]
    private bool _useForce = false;
    private bool _move = false;
    private Vector3 _shootDirection = Vector3.zero;

    private bool _initialKinematicValue = false;
    public Action<Projectile> OnProjectileDeactivated = default;

    private void Start()
    {
        _initialKinematicValue = _rigidbody.isKinematic;
    }

    private void OnEnable()
    {
        Reset();
        Invoke("DestroyProjectile", _duration);
    }

    public void SetShootDirection(Vector3 direction)
    {
        _shootDirection = direction;
        if (_useForce)
            _rigidbody.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (_move)
            transform.position += _shootDirection * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DestroyProjectile();
    }

    protected virtual void Reset()
    {
        _damage.enabled = false;
        _mainCollider.enabled = true;
        _normalState.gameObject.SetActive(true);
        _collisionState.gameObject.SetActive(false);
        _rigidbody.isKinematic = _initialKinematicValue;
        _move = !_useForce;
    }

    private void DestroyProjectile()
    {
        CancelInvoke();
        StartCoroutine(DestroyProjectileCoroutine());
    }

    private IEnumerator DestroyProjectileCoroutine()
    {
        //Invoke
        if (!_useForce)
            _move = false;
        //Damage Collider adjusted
        _mainCollider.enabled = false;
        _damage.enabled = true;
        _rigidbody.isKinematic = true;
        //Sprite change
        _normalState.gameObject.SetActive(false);
        _collisionState.gameObject.SetActive(true);

        yield return new WaitForSeconds(_destructionTime);
        OnProjectileDeactivated?.Invoke(this);
        gameObject.SetActive(false);
    }

}
