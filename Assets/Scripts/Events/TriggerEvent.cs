using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent OnTriggerEnter = default;
    public UnityEvent OnTriggerStay = default;
    public UnityEvent OnTriggerExit = default;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerEnter?.Invoke();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        OnTriggerStay?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnTriggerExit?.Invoke();
    }
}
