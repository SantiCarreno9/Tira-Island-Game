using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField, Range(0, 100)]
    private int _damagePercentage = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<CharacterController>().Damage(_damagePercentage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.GetComponent<CharacterController>().Damage(_damagePercentage);
    }
}
