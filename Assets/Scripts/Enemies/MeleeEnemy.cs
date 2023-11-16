using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField]
    private Rigidbody2D _rigidbody = default;
    [SerializeField]
    private float _movementSpeed = 10;

    public bool IsInAttackRange { get; set; } = false;

    private int _walkAnimParameter = Animator.StringToHash("IsWalking");
    private bool _walk = false;


    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        if (isDead)
            return;

        _walk = !IsInAttackRange && IsInDetectionRange;
        animator.SetBool(_walkAnimParameter, _walk);

        if (IsInAttackRange)
        {
            if (!hasAttacked)
            {
                Attack();
                hasAttacked = true;
            }
        }
        else StopAttacking();
    }

    private void FixedUpdate()
    {
        if (_walk)
        {
            int direction = (mainCharacter.transform.position.x < transform.position.x) ? -1 : 1;
            _rigidbody.velocity = Vector2.right * direction * _movementSpeed;
            Debug.Log(direction);
            return;
        }
    }

    public override void TakeHit()
    {
        base.TakeHit();
        _rigidbody.AddForce(transform.right * -1, ForceMode2D.Impulse);
    }

    public override void Kill()
    {
        _rigidbody.isKinematic = true;
        base.Kill();
    }

}
