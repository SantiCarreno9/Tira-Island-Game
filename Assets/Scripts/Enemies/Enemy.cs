using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected Animator animator = default;

    protected CharacterController mainCharacter = default;

    public bool IsInDetectionRange { get; set; } = false;

    protected bool isDead = false;
    private int _attackAnimParameter = Animator.StringToHash("IsAttacking");
    private int _takeHitAnimParameter = Animator.StringToHash("TakeHit");
    private int _killAnimParameter = Animator.StringToHash("Kill");


    protected virtual void Start()
    {
        mainCharacter = GameManager.Instance.Character;
    }

    protected virtual void Update()
    {
        if (isDead)
            return;

        if (IsInDetectionRange)
        {
            TurnTowardsTarget();
        }
    }

    public virtual void StartAttacking()
    {
        if (!animator.GetBool(_attackAnimParameter))
            animator.SetBool(_attackAnimParameter, true);
    }

    public virtual void StopAttacking()
    {
        animator.SetBool(_attackAnimParameter, false);
    }

    private void TurnTowardsTarget()
    {
        int yRotation = ((mainCharacter.transform.position.x < transform.position.x)) ? 180 : 0;
        transform.rotation = Quaternion.Euler(Vector3.up * yRotation);
    }

    public void TakeHit()
    {
        animator.SetTrigger(_takeHitAnimParameter);
    }

    public void Kill()
    {
        StopAttacking();
        animator.SetTrigger(_killAnimParameter);
        isDead = true;
    }

    public void DestroyEnemy()
    {
        Destroy(this.gameObject, 0.5f);
    }
}
