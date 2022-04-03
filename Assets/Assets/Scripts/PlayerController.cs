using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public float speed = 100f;
    // [SerializeField] float lerpValue = 20f;
    public float InputSensitivity = 0.01f;
    public bool CanSwerve = true;
    
    [SerializeField] float clampValue = 10f;
    
    private Rigidbody _rgb;
    private Vector3 _previousMousePosition;
    private float _desiredHorizontalPosition;
    private float _currentSpeed;

    public float CurrentSpeed
    {
        get => _currentSpeed;
        set => _currentSpeed = value;
    }

    private void Awake()
    {
        _rgb = GetComponent<Rigidbody>();
        _currentSpeed = speed;
        if (Instance == null)
        {
            Instance = this;
        }
    }

    protected void Update()
    {
        if (CanSwerve)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _previousMousePosition = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                var currentMousePosition = Input.mousePosition;
                var mouseDelta = currentMousePosition - _previousMousePosition;

                _desiredHorizontalPosition += mouseDelta.x * InputSensitivity;
                _desiredHorizontalPosition = Mathf.Clamp(_desiredHorizontalPosition, -clampValue, clampValue);

                _previousMousePosition = currentMousePosition;
            }
        }
    }

    protected void FixedUpdate()
    {
        Walk();
    }
    
    void Walk()
    {
        var velocity = new Vector3(0, _rgb.velocity.y, _currentSpeed);

        var currentPositionX = _rgb.position.x;
        var targetPositionX = _desiredHorizontalPosition;
        var requiredVelocity = (targetPositionX - currentPositionX) / Time.deltaTime;
        velocity.x = requiredVelocity;

        _rgb.velocity = velocity;

    }
}

