using System.Drawing;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] private SpringJoint _joint;
    [SerializeField] private float _hitPowerSpring = 2500;
    [SerializeField] private float _idlePowerSpring = 250;
    [SerializeField] private float _currentPowerSpring;
    private bool _is—ompression = false;
    private bool _isAfterHit = false;
    private float _maxTimerAfterHit = 1;
    private float _currTimerAfterHit = 0;

    void Start()
    {
        _currentPowerSpring = _idlePowerSpring;
        _joint.spring = _currentPowerSpring;
    }

    void Update()
    {
        if (_isAfterHit)
        {
            if (_currTimerAfterHit > 0)
            {
                _currTimerAfterHit -= Time.deltaTime;
            }
            else
            {
                _currentPowerSpring = _idlePowerSpring;
                _joint.spring = _currentPowerSpring;
                _isAfterHit = false;
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            _is—ompression = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _is—ompression = false;
        }
    }

    private void FixedUpdate()
    {
        if (_is—ompression && _currentPowerSpring > 0)
        {
            _currentPowerSpring -= _idlePowerSpring / 2 * Time.deltaTime;
            _joint.spring = Mathf.Clamp(_currentPowerSpring, 0, _hitPowerSpring);
        }
        else if (!_is—ompression && _currentPowerSpring < _idlePowerSpring)
        {
            _currentPowerSpring = _hitPowerSpring;
            _joint.spring = _currentPowerSpring;

            _currTimerAfterHit = _maxTimerAfterHit;
            _isAfterHit = true;
        }
    }
}
