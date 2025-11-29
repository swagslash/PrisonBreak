using System;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionController: MonoBehaviour
{
    [SerializeField] Camera playerCamera;

    [SerializeField] TextMeshProUGUI interactionText;

    [SerializeField] float interactionDistance = 3f;

    private IInteractable currentInteractable;
    private InputAction interactAction;
    InputAction moveAction;
    InputAction jumpAction;


    public void Interact()
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }
    
    private void Start()
    {
        Debug.Log("Interaction controller initialized!");
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        interactAction = InputSystem.actions.FindAction("Interact");
        // Debug.Log("Interact action found: " + (interactAction != null));
    }

    private void Update()
    {
        // Debug.Log("Interact action state: " + interactAction.IsPressed());
        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        if (interactAction.IsPressed())
        {
            // your jump code here
            Debug.Log("Interact pressed");
            // Interact();
        }

        if (jumpAction.IsPressed())
        {
            Debug.Log("Jump pressed");
        }
        
        // UpdateCurrectInteractable();
        // UpdateInteractionInput();
    }

    private void UpdateCurrectInteractable()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                currentInteractable = interactable;
                interactionText.text = interactable.InteractionMessage;
                // interactionText.gameObject.SetActive(true);
                return;
            }
        }

        currentInteractable = null;
        // interactionText.gameObject.SetActive(false);
    }
    
    // private void OnDrawGizmos()
    // {
    //     if (playerCamera == null) return;
    //
    //     Gizmos.color = Color.red;
    //     Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
    //     Gizmos.DrawRay(ray.origin, ray.direction * interactionDistance);
    // }
    
    private void UpdateInteractionInput()
    {
        Debug.Log("Interact action state: " + interactAction.ReadValue<float>());
        if (interactAction.IsPressed())
        {
            // your jump code here
            Debug.Log("Interact pressed");
            // Interact();
        }
    }
}