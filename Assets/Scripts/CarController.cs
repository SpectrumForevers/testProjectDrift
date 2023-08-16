using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Add scripts from game objects")]
    [SerializeField] VariableJoystick variableJoystick;
    [SerializeField] InputManager inputManager;
    [Header("Settings car")]
    [SerializeField] float moveSpeed = 50;
    [SerializeField] float maxSpeed = 15;
    [SerializeField] float accelerationSpeed = 20f;
    [Range(0f, 1f)]
    [SerializeField] float drag = 0.98f;
    [SerializeField] float steerAngle = 20;
    [SerializeField] float traction = 1;

    // Variables
    private Vector3 moveForce;
    [Range (0f, 1f)]
    private float acceleration = 0f;
    private bool startMoveCar = false;

    private void Start()
    {
        variableJoystick = GameManager.Instance.GetVariableJoystick();
    }
    private void Update()
    {
        if(inputManager != null)
        {
            if (inputManager.GetTypeClick() == 1)
            {
                startMoveCar = true;
            }
            if (inputManager.GetTypeClick() == 2 || inputManager.GetTypeClick() == 0)
            {
                startMoveCar = false;
                acceleration = 0f;
            }

        }
        
        if (startMoveCar == true)
        {
            // Moving
            acceleration += accelerationSpeed * Time.deltaTime;
            if (acceleration >= 1f)
            {
                acceleration = 1f;
            }
            moveForce += transform.forward * moveSpeed * acceleration * Time.deltaTime;
            
        }
        transform.position += moveForce * Time.deltaTime;
        // Steering
        float steerInput = variableJoystick.Horizontal;
        
        transform.Rotate(Vector3.up * steerInput * moveForce.magnitude * steerAngle * Time.deltaTime);
        // Drag and max speed limit
        moveForce *= drag;
        moveForce = Vector3.ClampMagnitude(moveForce, maxSpeed);
        // Traction

        moveForce = Vector3.Lerp(moveForce.normalized, transform.forward, traction * Time.deltaTime) * moveForce.magnitude;
        Debug.DrawRay(transform.position, moveForce.normalized * 3);
        Debug.DrawRay(transform.position, transform.forward * 3, Color.blue);
    }
}
