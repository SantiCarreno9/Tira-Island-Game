using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected Animator animator = default;
    [SerializeField]
    private Collider2D _collider = default;    
    [SerializeField]
    private float _attackRate = 5;

    protected CharacterController mainCharacter = default;

    public bool IsInDetectionRange { get; set; } = false;

    protected bool isDead = false;
    protected bool hasAttacked = false;
    private int _attackAnimParameter = Animator.StringToHash("Attack");
    private int _takeHitAnimParameter = Animator.StringToHash("TakeHit");
    private int _killAnimParameter = Animator.StringToHash("Kill");

    public void SetMainCharacter(CharacterController mainCharacter)
    {
        this.mainCharacter = mainCharacter;
    }

    protected virtual void Start()
    {
        //mainCharacter = GameManager.Instance.Character;
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

    public virtual void Attack()
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

    public virtual void TakeHit()
    {
        animator.SetTrigger(_takeHitAnimParameter);
        StopAttacking();
    }

    public virtual void Kill()
    {
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
