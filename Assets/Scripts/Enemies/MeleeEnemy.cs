using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField]
    private float _movementSpeed = 10;

    private int _walkAnimParameter = Animator.StringToHash("IsWalking");
    private bool _walk = false;


    protected override void Update()
    {
        base.Update();

        if (isDead)
            return;

        if (hitTaken)
            return;

        _walk = !IsInCloseRange && IsInDetectionRange;
        animator.SetBool(_walkAnimParameter, _walk);

        if (IsInCloseRange)
        {
            if (!hasAttacked)
            {
                Attack();
                hasAttacked = true;
            }
        }
        else StopAttacking();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (hitTaken)
            return;

        if (_walk)
        {
            int direction = (mainCharacter.transform.position.x < transform.position.x) ? -1 : 1;
            rigidbody.velocity = Vector2.right * direction * _movementSpeed;
            return;
        }
    }

}
