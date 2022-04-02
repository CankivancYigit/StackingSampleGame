using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 100f;
    // [SerializeField] float lerpValue = 20f;
    public float InputSensitivity = 0.01f;
    public bool CanSwerve = true;
    
    [SerializeField] float clampValue = 10f;
    
    private Rigidbody rgb;
    private Vector3 PreviousMousePosition;
    private float DesiredHorizontalPosition;

    private void Awake()
    {
        rgb = GetComponent<Rigidbody>();
    }

    protected void Update()
    {
        if (CanSwerve)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PreviousMousePosition = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                var currentMousePosition = Input.mousePosition;
                var mouseDelta = currentMousePosition - PreviousMousePosition;

                DesiredHorizontalPosition += mouseDelta.x * InputSensitivity;
                DesiredHorizontalPosition = Mathf.Clamp(DesiredHorizontalPosition, -clampValue, clampValue);

                PreviousMousePosition = currentMousePosition;
            }
        }
    }

    protected void FixedUpdate()
    {
        Walk();
    }
    
    void Walk()
    {
        var velocity = new Vector3(0, rgb.velocity.y, speed);

        var currentPositionX = rgb.position.x;
        var targetPositionX = DesiredHorizontalPosition;
        var requiredVelocity = (targetPositionX - currentPositionX) / Time.deltaTime;
        velocity.x = requiredVelocity;

        rgb.velocity = velocity;

    }
}

