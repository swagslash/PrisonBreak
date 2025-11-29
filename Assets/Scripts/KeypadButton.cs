using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeypadButton : MonoBehaviour, IInteractable
{
    
    public string InteractionMessage { get; } = "Press 'E' to open the door";
    [Tooltip("Digit this button represents (1–9)")]
    public string digit = "1";

    // Called when object is clicked (works with mouse / raycast and Collider)
    private void OnMouseDown()
    {
        
        Debug.Log(digit);
        if (Keypad3D.Instance != null)
        {
            Keypad3D.Instance.PressKey(digit);
        }
    }
    
    public void Interact()
    {

        Debug.Log(digit);
        if (Keypad3D.Instance != null)
         {
             Keypad3D.Instance.PressKey(digit);
         }
        
        
    }
}