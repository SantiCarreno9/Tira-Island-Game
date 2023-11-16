using UnityEngine;

public class EnemyTriggerArea : MonoBehaviour
{
    private Enemy[] _enemiesWithinArea;

    private void Start()
    {
        _enemiesWithinArea = transform.GetComponentsInChildren<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_enemiesWithinArea == null)
            return;

        for (int i = 0; i < _enemiesWithinArea.Length; i++)
        {
            _enemiesWithinArea[i].SetMainCharacter(collision.GetComponent<CharacterController>());
            _enemiesWithinArea[i].IsInDetectionRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_enemiesWithinArea == null)
            return;

        for (int i = 0; i < _enemiesWithinArea.Length; i++)
            _enemiesWithinArea[i].IsInDetectionRange = false;
    }
}
