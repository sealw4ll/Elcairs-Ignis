using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class damagedBehaviour : MonoBehaviour
{
    [SerializeField] playerScript player;
    public Collider2D playerCollider;
    public GameObject hurtCollider;
    public Animator playerAnim;
    public float duration = 0.1f;

    public void playDamaged(Rigidbody2D rbTarget)
    {
        SceneController.instance.AudioManager.PlaySFX(SceneController.instance.AudioManager.get_hit);
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        player.setDamaged();
        playerCollider.enabled = false;
        hurtCollider.SetActive(true);
        yield return new WaitForSeconds(duration);
        playerCollider.enabled = true;
        hurtCollider.SetActive(false);
        player.resetDamaged();
    }
}
