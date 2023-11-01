using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private Vector3 _offset = Vector3.zero;

    private void Update()
    {
        transform.position = (_target.position.x * Vector3.right) + _offset;
    }
}
