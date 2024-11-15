using UnityEngine;

public class footstepSound : MonoBehaviour
{
    public void play()
    {
        SceneController.instance.AudioManager.PlaySFX(SceneController.instance.AudioManager.footsteps);
    }
}
