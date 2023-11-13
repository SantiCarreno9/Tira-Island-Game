using UnityEngine;

public class CloseRangeAttackController : MonoBehaviour
{
    [SerializeField]
    private GameObject _damageArea = default;

    public void EnableAttackArea()
    {
        if (!enabled)
            return;
        _damageArea.SetActive(true);
    }

    public void DisableAttackArea()
    {
        if (!enabled)
            return;
        _damageArea.SetActive(false);
    }
}
