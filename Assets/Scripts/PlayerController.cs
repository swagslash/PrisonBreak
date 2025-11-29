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

    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction lookAction;
    private Vector2 moveInput;
    private Vector2 lookInput;

    [SerializeField] private Camera playerCamera; // Assign in inspector or via code

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        playerInput = GetComponent<PlayerInput>();
        if (playerCamera == null)
            playerCamera = Camera.main;
        if (playerInput == null)
        {
            Debug.LogError("PlayerInput component not found on GameObject!");
            return;
        }
        moveAction = playerInput.actions.FindAction("Move", true);
        lookAction = playerInput.actions.FindAction("Look", true);
    }

    private void Update()
    {
        // Read input from InputActions
        if (moveAction != null && moveAction.enabled)
            moveInput = moveAction.ReadValue<Vector2>();
        else
            moveInput = Vector2.zero;
        if (lookAction != null && lookAction.enabled)
            lookInput = lookAction.ReadValue<Vector2>();
        else
            lookInput = Vector2.zero;
        HandleMovement();
        HandleLook();
    }

    private void HandleMovement()
    {
        // Debug.Log(moveInput);
        // Debug.Log(lookInput);
        
        // Use moveInput from Input System
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;
        Vector3 desiredMove = (forward * moveInput.y + right * moveInput.x).normalized;
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
        // Horizontal rotation (yaw) for player
        float yaw = lookInput.x * LookSensitivity * Time.smoothDeltaTime;
        transform.Rotate(Vector3.up * yaw);

        // Vertical rotation (pitch) for camera
        rotationX -= lookInput.y * LookSensitivity * Time.smoothDeltaTime;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        if (playerCamera != null)
            playerCamera.transform.localEulerAngles = new Vector3(rotationX, 0, 0);
    }
}
