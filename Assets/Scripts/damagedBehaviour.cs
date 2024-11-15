using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class damagedBehaviour : MonoBehaviour
{
    [SerializeField] playerScript player;
    public float duration = 0.2f;

    public void playDamaged(Rigidbody2D rbTarget)
    {
        SceneController.instance.AudioManager.PlaySFX(SceneController.instance.AudioManager.get_hit);
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        player.toggleDamaged();
        yield return new WaitForSeconds(duration);
        player.toggleDamaged();
    }
}
