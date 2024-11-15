using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator transitionAnim;

    public void PlayGame()
    {
        SceneController.instance.ResetTimer();
        transitionAnim.SetTrigger("End");
        // SceneController.instance.NextLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        transitionAnim.SetTrigger("Start");
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
