using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    private int _damagePoints = 10;
    [SerializeField]
    private bool _oneShot = false;

    public void SetDamagePoints(int damagePoints)
    {
        this._damagePoints = damagePoints;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health health))
        {
            if (_oneShot) health.DecreaseHealthBy(health.CurrentHealthPoints);
            else health.DecreaseHealthBy(_damagePoints);
        }
    }

}
