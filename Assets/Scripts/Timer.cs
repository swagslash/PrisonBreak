using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    /// <summary>
    /// A simple Timer class to handle timing functionality.
    /// </summary>
    public class CountdownTimer: MonoBehaviour
    {
        public float duration;
        
        private float timeRemaining;
        private bool isRunning;
        public bool IsFinished => !isRunning && timeRemaining <= 0f;
        
        TextMeshProUGUI timerText;

        private void Start()
        {
            isRunning = true;
            timeRemaining = duration;
            timerText = GetComponent<TextMeshProUGUI>();
            UpdateText();
        }

        void Update()
        {
            if (isRunning)
            {
                timeRemaining -= Time.deltaTime;
                if (timeRemaining <= 0f)
                {
                    timeRemaining = 0f;
                    isRunning = false;
                    OnTimerFinished();
                }
                UpdateText();
            }
        }
        
        void UpdateText()
        {
            if (timerText != null)
            {
                timerText.text = FormatTime(timeRemaining);
            }
        }
        
        string FormatTime(float time)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(time);
            return string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        }
        
        void OnTimerFinished()
        {
            Debug.Log("Timer finished!");
            // Additional logic when the timer finishes can be added here.
            // restart scene 
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                 UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}