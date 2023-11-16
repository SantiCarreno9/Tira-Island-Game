using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected Animator animator = default;
    [SerializeField]
    private Collider2D _collider = default;
    [SerializeField]
    protected new Rigidbody2D rigidbody = default;

    [Space]
    [SerializeField]
    private float _attackRate = 5;

    protected CharacterController mainCharacter = default;

    public bool IsInDetectionRange { get; set; } = false;
    public bool IsInCloseRange { get; set; } = false;

    protected bool isDead = false;
    protected bool hasAttacked = false;

    private int _attackAnimParameter = Animator.StringToHash("Attack");
    private int _takeHitAnimParameter = Animator.StringToHash("TakeHit");
    private int _killAnimParameter = Animator.StringToHash("Kill");

    //Hit Logic
    protected bool hitTaken = false;
    private float _hitDuration = 0.5f;
    private float _hitTime = 0;
    private float _takeHitForce = 0.5f;
    private Vector2 _takeHitDirection = Vector2.zero;

    public void SetMainCharacter(CharacterController mainCharacter)
    {
        this.mainCharacter = mainCharacter;
    }

    protected virtual void Update()
    {
        if (isDead)
            return;

        //Hit Logic
        if (hitTaken)
        {
            _hitTime += Time.deltaTime;
            if (_hitTime >= _hitDuration)
            {
                hitTaken = false;
                _hitTime = 0;
            }
            return;
        }

        if (IsInDetectionRange && !IsInCloseRange)
        {
            TurnTowardsTarget();
        }
    }

    protected virtual void FixedUpdate()
    {
        //Hit Logic
        if (hitTaken)
        {
            rigidbody.velocity = _takeHitDirection * _takeHitForce;
            return;
        }
        else rigidbody.velocity = Vector2.zero;
    }

    public void Attack()
    {
        animator.SetTrigger(_attackAnimParameter);
    }

    public void OnAttack()
    {
        Invoke("Attack", _attackRate);
    }

    public virtual void StopAttacking()
    {
        hasAttacked = false;
        CancelInvoke("Attack");
    }

    private void TurnTowardsTarget()
    {
        int yRotation = ((mainCharacter.transform.position.x < transform.position.x)) ? 180 : 0;
        transform.rotation = Quaternion.Euler(Vector3.up * yRotation);
    }

    public void TakeHit(Vector2 direction)
    {
        animator.SetTrigger(_takeHitAnimParameter);
        StopAttacking();
        _takeHitDirection = direction;
        hitTaken = true;
    }

    public void Kill()
    {
        rigidbody.isKinematic = true;
        StopAttacking();
        _collider.enabled = false;
        animator.SetTrigger(_killAnimParameter);
        isDead = true;
    }

    public void DestroyEnemy()
    {
        Destroy(this.gameObject, 0.5f);
    }
}
