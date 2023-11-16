using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int _initialHealthPoints = 100;
    private int _currentHealthPoints = 0;

    public UnityEvent OnHealthIncreased = default;
    public UnityEvent OnHealthDecreased = default;
    public UnityEvent<Vector2> OnHitReceived = default;
    public UnityEvent<float> OnHealthPercentageChanged = default;
    public UnityEvent OnZeroHealth = default;

    public int CurrentHealthPoints => _currentHealthPoints;

    void Start()
    {
        _currentHealthPoints = _initialHealthPoints;
    }

    public void IncreaseHealthBy(int amount)
    {
        _currentHealthPoints += amount;
        if (_currentHealthPoints > _initialHealthPoints)
            _currentHealthPoints = _initialHealthPoints;

        float percentage = ((float)_currentHealthPoints / _initialHealthPoints);
        OnHealthIncreased?.Invoke();
        OnHealthPercentageChanged?.Invoke(percentage);
        Debug.Log(gameObject.name + " health percentage " + percentage);
    }

    public void DecreaseHealthBy(int amount)
    {
        _currentHealthPoints -= amount;
        if (_currentHealthPoints < 0)
            _currentHealthPoints = 0;

        float percentage = ((float)_currentHealthPoints / _initialHealthPoints);
        OnHealthDecreased?.Invoke();
        OnHealthPercentageChanged?.Invoke(percentage);

        if (_currentHealthPoints == 0)
            OnZeroHealth?.Invoke();

    }

    public void SetHitDirection(Vector2 direction)
    {
        if (direction.y > 0)
            direction = transform.right * -1;
        OnHitReceived?.Invoke(direction);
    }
}
