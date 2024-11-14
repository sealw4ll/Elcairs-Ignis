using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneController.instance.NextLevel();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
