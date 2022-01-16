using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallMovement : MonoBehaviour
{
    [SerializeField] private float _minSpeed;
    [SerializeField] private List<Vector2> _initDirections;

    private Vector3 _lastFrameVelocity;
    private Rigidbody _rigidBody;

    private bool _isActive;

    public void ResetSpeed()
    {
        _rigidBody.velocity = Vector3.zero;
        _isActive = false;
    }

    public void SetSpeed(int difficultySpeed)
    {
        _minSpeed = difficultySpeed;
    }

    public void RunBall()
    {
        _rigidBody.velocity = ComputeSpeed() * _initDirections.RandomItem();
        _isActive = true;
    }

    private void OnValidate()
    {
        for (var index = 0; index < _initDirections.Count; index++)
        {
            var initDirection = _initDirections[index];
            for (int i = 0; i < 1; i++)
            {
                if (initDirection[i] > 1)
                {
                    initDirection[i] = 1;
                }
                else if (initDirection[i] < -1)
                {
                    initDirection[i] = -1;
                }
            }

            _initDirections[index] = initDirection;
        }
    }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _lastFrameVelocity = _rigidBody.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isActive == false) return;
        
        _rigidBody.velocity = ComputeSpeed() * ComputeDirection(collision);
    }

    private Vector3 ComputeDirection(Collision collision)
    {
        return Vector3.Reflect(_lastFrameVelocity.normalized, collision.contacts[0].normal);
    }

    private float ComputeSpeed()
    {
        var speed = _lastFrameVelocity.magnitude;
        return Mathf.Max(speed, _minSpeed);
    }
}