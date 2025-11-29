using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Keypad3D : MonoBehaviour
{
    public static Keypad3D Instance;

    [Header("Correct Code (4 digits)")]
    public string correctCode = "1234";

    [Header("Events")]
    public UnityEvent onCorrectCode;
    public UnityEvent onWrongCode;

    [Header("Optional Display (TextMeshPro)")]
    public TextMeshPro display; // or TextMeshPro (3D)

    private string currentInput = "";

    private void Awake()
    {
        Instance = this;
    }

    public void PressKey(string digit)
    {
        if (currentInput.Length >= 4)
            return;

        currentInput += digit;
        Debug.Log("Pressed: " + digit + " | Current: " + currentInput);

        if (display != null)
            display.text = currentInput;

        if (currentInput.Length == 4)
            CheckCode();
    }

    private void CheckCode()
    {
        if (currentInput == correctCode)
        {
            Debug.Log("Correct Code!");
            onCorrectCode?.Invoke();
        }
        else
        {
            Debug.Log("Wrong Code!");
            onWrongCode?.Invoke();
        }

        ResetKeypad();
    }

    private void ResetKeypad()
    {
        currentInput = "";
        if (display != null)
            display.text = "";
    }
}