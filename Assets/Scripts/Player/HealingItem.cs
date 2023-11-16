using UnityEngine;

public class HealingItem : MonoBehaviour
{
    [SerializeField]
    private int _healingPoints = default;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            health.IncreaseHealthBy(_healingPoints);
            Destroy(gameObject);
        }
    }
}
