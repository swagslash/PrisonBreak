using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeypadButton : MonoBehaviour, IInteractable
{
    
    [Tooltip("Digit this button represents (1–9)")]
    public string digit = "1";
    public string InteractionMessage => $"Press 'E' to type {digit}";

    // Called when object is clicked (works with mouse / raycast and Collider)
    private void OnMouseDown()
    {
        
        Debug.Log(digit);
        if (Keypad3D.Instance != null)
        {
            Keypad3D.Instance.PressKey(digit);
        }
    }
    
    public void Interact(Inventory inventory)
    {
        Debug.Log(digit);
        if (Keypad3D.Instance != null)
        {
            Keypad3D.Instance.PressKey(digit);
        }
    }
}