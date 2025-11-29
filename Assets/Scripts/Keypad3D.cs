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
    public TextMeshPro display;
    public TextMeshPro attempts;
    private string currentInput = "";
    
    private bool codeEntered = false;
    
    private int numberOfAttempts = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void PressKey(string digit)
    {
        if (codeEntered)
        {
            ResetKeypad();
            codeEntered = false;
        }
        if (currentInput.Length >= 4)
            return;

        currentInput += digit;

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
            display.color = Color.green;
            display.fontSize = 4;
            display.text = "Granted";
        }
        else if(numberOfAttempts == 2)
        {
            Debug.Log("Wrong Code!");
            onWrongCode?.Invoke();
            display.color = Color.red;
            display.fontSize = 4;
            display.text = "Locked";
            numberOfAttempts++;
        }
        else 
        {
            Debug.Log("Wrong Code!");
            onWrongCode?.Invoke();
            display.color = Color.red;
            display.fontSize = 4;
            display.text = "Denied";
            if (numberOfAttempts == 0)
            {
                attempts.text = ".";
            }
            if (numberOfAttempts == 1)
            {
                attempts.text = "..";
            }
            numberOfAttempts++;
        }
        codeEntered = true;
        
    }

    private void ResetKeypad()
    {
        currentInput = "";
        if (display != null)
        {
             display.text = "";
             display.fontSize = 5;
             display.color = Color.white;
        }
           
    }
}