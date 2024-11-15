using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TotalTE : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerTextTotal;
    [SerializeField] Timer timer;
    static float totalTime;

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            totalTime = 0f;
        }
        GetTTime();
    }

    public void GetTTime()
    {
        float timeGot = SceneController.instance.GetTime();
        int minutes = Mathf.FloorToInt(timeGot / 60);
        int seconds = Mathf.FloorToInt(timeGot % 60);
        int milisec = Mathf.FloorToInt((timeGot * 100) % 100);
        timerTextTotal.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milisec);
    }
}
