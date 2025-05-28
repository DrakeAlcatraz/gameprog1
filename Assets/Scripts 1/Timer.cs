using UnityEngine;
using TMPro;
using System.Net.NetworkInformation;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public TextMeshProUGUI timerText;
    private float elapsedTime = 0f;
    private bool isRunning = true;

    void Update()
    {
        if (isRunning)
        {
          
            elapsedTime += Time.deltaTime;

            int minutes = Mathf.FloorToInt(elapsedTime / 60F);
            int seconds = Mathf.FloorToInt(elapsedTime % 60F);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public float getTimePassed()
    {
        return elapsedTime;
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void Start()
    {
      
        elapsedTime = 0f;
        timerText.text = "00:00";
    }

    public void Awake()
    {
          instance = this;
    }

    
}
