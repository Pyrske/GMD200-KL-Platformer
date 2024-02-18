using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private TMP_Text timerText;
    [SerializeField] private bool restartTimer = false;

    private void Start()
    {
        if (restartTimer) TimerData.StartTimer();
        timerText = GetComponent<TMP_Text>();
    }
    void Update()
    {
        float timeLeft = TimerData.TimeLeft();
        if (timeLeft <= 0) SceneManager.LoadScene(0);
        int minutes = Mathf.FloorToInt(timeLeft / 60f);
        float seconds = timeLeft - minutes * 60f;
        timerText.text = String.Format("{0:00}:{1:00.00}", minutes, seconds);
    }
}
