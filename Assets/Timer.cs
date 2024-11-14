using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float passedTime;

    void Update()
    {
        passedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(passedTime / 60);
        int seconds = Mathf.FloorToInt(passedTime % 60);
        int milisec = Mathf.FloorToInt((passedTime * 100) % 100);
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milisec);
    }
}
