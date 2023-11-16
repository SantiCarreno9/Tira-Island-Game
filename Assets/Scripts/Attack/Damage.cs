using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    private int _damagePoints = 10;
    [SerializeField]
    private bool _oneShot = false;
    [SerializeField]
    private bool _damageOnTrigger = true;    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!enabled)
            return;

        if (!_damageOnTrigger)
            return;

        if (collision.gameObject.TryGetComponent(out Health health))
            DamageOther(health);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!enabled)
            return;
        if (_damageOnTrigger)
            return;

        if (collision.gameObject.TryGetComponent(out Health health))
            DamageOther(health);
    }

    private void DamageOther(Health health)
    {
        if (_oneShot) health.DecreaseHealthBy(health.CurrentHealthPoints);
        else health.DecreaseHealthBy(_damagePoints);
        health.SetHitDirection(transform.right);
    }

}
