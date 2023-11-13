using UnityEngine;
using UnityEngine.Events;

public class CollisionEvent : MonoBehaviour
{
    public UnityEvent OnCollisionEnter = default;
    public UnityEvent OnCollisionExit = default;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollisionEnter?.Invoke();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        OnCollisionExit?.Invoke();
    }
}
