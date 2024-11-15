using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NextScene : MonoBehaviour
{
    [SerializeField] GameObject nextScene;
    [SerializeField] Animator transitionAnim;

    public void Result()
    {
        nextScene.SetActive(true);
        Time.timeScale = 0;
        SceneController.instance.AddTime( this.gameObject.GetComponent<TimeElapsed>().FinalTime() );
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void nextLevel()
    {
        transitionAnim.SetTrigger("End");
        // SceneController.instance.NextLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        transitionAnim.SetTrigger("Start");
        Time.timeScale = 1;
    }
}
