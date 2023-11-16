using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private CapsuleCollider2D _collider;

    [Header("Movement Variables")]
    [SerializeField]
    private LayerMask _plaftormLayerMask;
    [SerializeField]
    private float _walkingSpeed = 3f;
    [SerializeField]
    private float _runningSpeed = 5f;
    [SerializeField]
    private float _jumpForce = 1f;
    [SerializeField]
    private float _attackRate = 0.3f;

    private float _movementDirection = 0f;
    private float _movementSpeed = 0f;
    private bool _jump = false;
    private bool _canMove = true;

    //Attack logic
    private bool _attack = false;
    private bool _canAttack = true;
    private float _currentAttackDelay = 0;

    //Animator parameters
    private int _speedAnimParameter = Animator.StringToHash("Speed");
    private int _jumpAnimParameter = Animator.StringToHash("Jump");
    private int _isGroundedAnimParameter = Animator.StringToHash("IsGrounded");
    private int _attackAnimParameter = Animator.StringToHash("Shoot");
    private int _takeHitAnimParameter = Animator.StringToHash("TakeHit");
    private int _deathAnimParameter = Animator.StringToHash("Died");

    //Hit Logic
    private bool _hitTaken = false;
    private float _hitDuration = 0.5f;
    private float _hitTime = 0;
    private float _takeHitForce = 0.5f;
    private Vector2 _takeHitDirection = Vector2.zero;

    void Update()
    {        
        GetUserInput();
        PlayAnimations();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    public void ResumePlayerMovement()
    {
        _canMove = true;
    }

    public void StopPlayerMovement()
    {
        _canMove = false;
    }

    private void GetUserInput()
    {
        if (!_canMove)
            return;

        //Hit Logic
        if (_hitTaken)
        {
            _hitTime += Time.deltaTime;
            if (_hitTime >= _hitDuration)
            {
                _hitTaken = false;
                _hitTime = 0;
            }
            return;
        }

        //Movement
        _movementDirection = Input.GetAxis("Horizontal");
        if (Input.GetButton("Run"))
            _movementSpeed = _runningSpeed;
        else _movementSpeed = _walkingSpeed;

        _jump = IsGrounded() && Input.GetButtonDown("Jump");

        //Abilities                
        _attack = _canAttack && Input.GetButtonDown("Fire");
        if (_attack || !_canAttack)
        {
            _canAttack = false;
            _currentAttackDelay += Time.deltaTime;
            if (_currentAttackDelay >= _attackRate)
            {
                _currentAttackDelay = 0;
                _canAttack = true;
            }
        }
    }

    private void MoveCharacter()
    {
        //Hit Logic
        if (_hitTaken)
        {
            _rigidbody.velocity = _takeHitDirection * _takeHitForce;
            return;
        }

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
        RaycastHit2D raycastHit = Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0, Vector2.down, 0.2f, _plaftormLayerMask);
        return raycastHit.collider != null;
    }

    #region ANIMATIONS

    private void PlayAnimations()
    {
        float normalizedSpeed = _movementSpeed / _walkingSpeed;
        _animator.SetFloat(_speedAnimParameter, Mathf.Abs(normalizedSpeed * _movementDirection));

        if (_jump) _animator.SetTrigger(_jumpAnimParameter);
        if (_attack) _animator.SetTrigger(_attackAnimParameter);
        _animator.SetBool(_isGroundedAnimParameter, IsGrounded());
    }

    #endregion    

    public void TakeHit(Vector2 direction)
    {
        Debug.Log("Damage Received");
        _takeHitDirection = direction;
        _hitTaken = true;
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
