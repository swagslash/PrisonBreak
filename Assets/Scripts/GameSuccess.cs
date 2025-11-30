using System;
using TMPro;
using UnityEngine;

public class GameSuccess : MonoBehaviour
{
    public TextMeshProUGUI gameOverSuccessText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke(nameof(RestartGame), 3f);
            gameOverSuccessText?.gameObject.SetActive(true);
        }
    }

    void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
}