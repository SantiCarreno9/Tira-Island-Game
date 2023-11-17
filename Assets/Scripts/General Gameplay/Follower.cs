using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private Vector3 _offset = Vector3.zero;

    public bool Follow { get; set; } = true;

    private void Update()
    {
        if (Follow)
            transform.position = _target.position + _offset;
    }
}
