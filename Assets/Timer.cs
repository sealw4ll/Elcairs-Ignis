using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float passedTime;
    static float recordTime;

    void Awake()
    {
        recordTime = PlayerPrefs.GetFloat("TotalTime", 0f);
    }

    void Update()
    {
        passedTime += Time.deltaTime;
        recordTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(passedTime / 60);
        int seconds = Mathf.FloorToInt(passedTime % 60);
        int milisec = Mathf.FloorToInt((passedTime * 100) % 100);
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milisec);
    }

    public float GetPassedTime()
    {
        return passedTime;
    }

    public float GetRecordTime()
    {
        return recordTime;
    }

    public void ResetTimer()
    {
        passedTime = 0f;
        recordTime = 0f;
        PlayerPrefs.SetFloat("TotalTime", 0f);
        PlayerPrefs.Save();
    }
}
