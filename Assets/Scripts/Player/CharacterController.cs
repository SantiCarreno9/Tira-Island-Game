using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
    [Header("Components")]    
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private BoxCollider2D _boxCollider;

    [Header("Movement Variables")]
    [SerializeField]
    private LayerMask _plaftormLayerMask;
    [SerializeField]
    private float _walkingSpeed = 3f;
    [SerializeField]
    private float _runningSpeed = 5f;
    [SerializeField]
    private float _jumpForce = 1f;

    [Space]
    [Header("Events")]
    public UnityEvent OnShoot = default;

    private float _movementDirection = 0f;
    private float _movementSpeed = 0f;
    private bool _jump = false;
    private bool _attack = false;

    //Animator parameters
    private int _speedAnimParameter = Animator.StringToHash("Speed");
    private int _jumpAnimParameter = Animator.StringToHash("Jump");
    private int _isGroundedAnimParameter = Animator.StringToHash("IsGrounded");
    private int _attackAnimParameter = Animator.StringToHash("IsShooting");
    private int _takeHitAnimParameter = Animator.StringToHash("TakeHit");
    private int _deathAnimParameter = Animator.StringToHash("Died");


    void Update()
    {
        GetUserInput();
        PlayAnimations();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void GetUserInput()
    {
        //Movement
        _movementDirection = Input.GetAxis("Horizontal");
        if (Input.GetButton("Run"))
            _movementSpeed = _runningSpeed;
        else _movementSpeed = _walkingSpeed;

        _jump = IsGrounded() && Input.GetButtonDown("Jump");

        //Abilities
        _attack = Input.GetButtonDown("Fire");
        if (_attack) OnShoot?.Invoke();
    }

    private void MoveCharacter()
    {
        _rigidbody.velocity = new Vector3(_movementSpeed * _movementDirection, _rigidbody.velocity.y);
        if (_movementDirection != 0)
        {
            int yRotation = (_movementDirection < 0) ? 180 : 0;
            transform.rotation = Quaternion.Euler(Vector3.up * yRotation);
        }
    }

    public void Jump()
    {
        _rigidbody.velocity = Vector2.up * _jumpForce;
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0, Vector2.down, 0.2f, _plaftormLayerMask);
        return raycastHit.collider != null;
    }

    #region ANIMATIONS

    private void PlayAnimations()
    {
        float normalizedSpeed = _movementSpeed / _walkingSpeed;
        _animator.SetFloat(_speedAnimParameter, Mathf.Abs(normalizedSpeed * _movementDirection));

        if (_jump) _animator.SetTrigger(_jumpAnimParameter);

        _animator.SetBool(_attackAnimParameter, _attack);
        _animator.SetBool(_isGroundedAnimParameter, IsGrounded());
    }

    #endregion    

    public void PlayTakeHitAnimation()
    {
        Debug.Log("Damage Received");
        //_animator.SetTrigger(_damageAnimParameter);
    }

    public void PlayDeadAnimation()
    {
        Debug.Log("You are dead");
        //_animator.SetTrigger(_deathAnimParameter);        
    }

    public void PlayIncreaseHealthAnimation()
    {
        Debug.Log("Your health has increased");
    }
}
