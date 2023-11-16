using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    private int _damagePoints = 10;
    [SerializeField]
    private bool _oneShot = false;
    [SerializeField]
    private bool _damageOnTrigger = true;

    private void OnDisable()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!enabled)
            return;

        if (!_damageOnTrigger)
            return;
        Debug.Log(gameObject.name + " collided with " + collision.gameObject.name);
        if (collision.gameObject.TryGetComponent(out Health health))
        {
            if (_oneShot) health.DecreaseHealthBy(health.CurrentHealthPoints);
            else health.DecreaseHealthBy(_damagePoints);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!enabled)
            return;
        if (_damageOnTrigger)
            return;
        Debug.Log(gameObject.name + " collided with " + collision.gameObject.name);
        if (collision.gameObject.TryGetComponent(out Health health))
        {
            if (_oneShot) health.DecreaseHealthBy(health.CurrentHealthPoints);
            else health.DecreaseHealthBy(_damagePoints);
        }
    }

}
