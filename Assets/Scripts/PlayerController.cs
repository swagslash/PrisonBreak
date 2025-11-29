using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float WalkingSpeed = 5f;
    public float LookSensitivity = 0.2f;
    public float Gravity = -9.81f * 2;

    private CharacterController characterController;
    private Vector3 moveDirection;
    private float verticalVelocity;

    private float rotationX = 0;
    private float lookXLimit = 45.0f;
    

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void Update()
    {
        HandleMovement();
        HandleLook();
    }
    
    private void HandleMovement()
    {
        float moveZ = Keyboard.current.aKey.isPressed ? -1 : Keyboard.current.dKey.isPressed ? 1 : 0;
        float moveX = Keyboard.current.sKey.isPressed ? -1 : Keyboard.current.wKey.isPressed ? 1 : 0;

        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        Vector3 desiredMove = (forward * moveX + right * moveZ).normalized;

        if (characterController.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity += Gravity * Time.deltaTime;
        }

        moveDirection = desiredMove * WalkingSpeed;
        moveDirection.y = verticalVelocity;

        characterController.Move(moveDirection * Time.deltaTime);
    }
    
    private void HandleLook()
    {
        float mouseX = Mouse.current.delta.x.value * LookSensitivity * Time.deltaTime;
        float mouseY = Mouse.current.delta.y.value * LookSensitivity * Time.deltaTime;
        
        transform.Rotate(Vector3.up * mouseX);
        
        rotationX += -mouseY;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}
