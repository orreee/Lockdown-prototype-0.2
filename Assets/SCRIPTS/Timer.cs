using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private Text dayText;

    [Range(0, 60)]
    public int seconds;
    [Range(0, 23)]
    public int minutes;
    [Range(1, 30)]
    public int day;

    public float speed = 1;
    public float currentSeconds;
    private int timerDefault;

    void Start()
    {
        timerDefault = 0;
        timerDefault += (seconds + (minutes * 60));
        currentSeconds = timerDefault;
    }
  
    void Update()
    {
        if((currentSeconds += speed * Time.deltaTime) >= 1440)
        {
            currentSeconds = 0;
            day++;
            dayText.text = "Day: " + day;
        }
            
        timerText.text = TimeSpan.FromSeconds(currentSeconds).ToString(@"mm\:ss");
        
    }
}
