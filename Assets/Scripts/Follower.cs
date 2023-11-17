using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private Vector3 _offset = Vector3.zero;


    private void Update()
    { 
        transform.position = new Vector3(_target.position.x, _target.position.y, 0) + _offset;
    }
}
