using UnityEngine;
using TMPro;

public class TimeElapsed : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerTextElapsed;
    [SerializeField] Timer timer;

    void Update()
    {
        GetTime();
    }

    public void GetTime()
    {
        float timeGot = timer.GetPassedTime();
        int minutes = Mathf.FloorToInt(timeGot / 60);
        int seconds = Mathf.FloorToInt(timeGot % 60);
        int milisec = Mathf.FloorToInt((timeGot * 100) % 100);
        timerTextElapsed.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milisec);
    }
}
