using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    public AudioBehaviour AudioBehaviour;

    private float totalTime;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            AudioBehaviour = GetComponentInChildren<AudioBehaviour>();

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetTimer()
    {
        totalTime = 0;
    }

    public void AddTime(float time)
    {
        totalTime += time;
    }

    public float GetTime()
    {
        return totalTime;
    }
}
