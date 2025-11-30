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

    Inventory playerInventory;
    
    private IInteractable currentInteractable;
    
    private InputAction interactAction;

    public void Start()
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }
        if (playerInventory == null)
        {
            playerInventory = GetComponent<Inventory>();
        }
        interactAction = InputSystem.actions.FindAction("Player/Interact");
    }
    
    public void Interact()
    {
        currentInteractable?.Interact(inventory: playerInventory);
    }

    private void Update()
    {
        UpdateCurrectInteractable();
        UpdateInteractionInput();
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
                interactionText.gameObject.SetActive(true);
                return;
            }
        }

        currentInteractable = null;
        interactionText.gameObject.SetActive(false);
    }
    
    private void OnDrawGizmos()
    {
        if (playerCamera == null) return;
    
        Gizmos.color = Color.red;
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        Gizmos.DrawRay(ray.origin, ray.direction * interactionDistance);
    }
    
    private void UpdateInteractionInput()
    {
        if (interactAction.WasPressedThisFrame())
        {
            Interact();
        }
    }
}