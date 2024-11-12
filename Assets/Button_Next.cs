using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Next : MonoBehaviour
{
    public void nextLevel()
    {
        SceneController.instance.NextLevel();
    }
}
