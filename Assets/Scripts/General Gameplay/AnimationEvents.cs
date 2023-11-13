using UnityEngine;
using UnityEngine.Events;

public class AnimationEvents : MonoBehaviour
{
    public UnityEvent OnJump = default;
    public UnityEvent OnAttackStarted = default;
    public UnityEvent OnAttackFinished = default;
    public UnityEvent OnDied = default;

    private void Jump()
    {
        OnJump?.Invoke();
    }

    private void StartAttack()
    {
        OnAttackStarted?.Invoke();
    }

    private void FinishAttack()
    {
        OnAttackFinished?.Invoke();
    }

    private void Die()
    {
        OnDied?.Invoke();
    }
}
