using UnityEngine;
using UnityEngine.Events;

public class RangedEnemy : Enemy
{
    [SerializeField]
    private float _shootRate = 5;

    public UnityEvent OnShoot = default;

    protected override void Update()
    {
        base.Update();
        if (IsInDetectionRange)
        {
            StartAttacking();
        }
    }

    public override void StartAttacking()
    {
        base.StartAttacking();
        OnShoot?.Invoke();
    }
}
