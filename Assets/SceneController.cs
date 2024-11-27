using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.InputSystem;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    public AudioManager AudioManager;

    private float totalTime;

    public PauseMenu pauseMenu;

    InputAction pause;
    private void Start()
    {
        pause = InputSystem.actions.FindAction("Pause");
    }

    public void Update()
    {
        if (pause.WasPressedThisFrame() && pauseMenu)
        {
            pauseMenu.togglePause();
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            AudioManager = GetComponentInChildren<AudioManager>();

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
