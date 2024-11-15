using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class damagedBehaviour : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] playerScript player;
    public float knockback = 10f;
    public float duration = 0.2f;

    public void playDamaged(Rigidbody2D rbTarget)
    {
        Vector2 dir = new Vector2((Mathf.Sign(transform.localScale.x)), 0);

        if (rbTarget != null)
        {
            if (rbTarget.linearVelocity != Vector2.zero)
                dir = rbTarget.linearVelocity * -1;
            if (dir.x == 0)
                dir.x = (Mathf.Sign(transform.localScale.x));
        }

        SceneController.instance.AudioManager.PlaySFX(SceneController.instance.AudioManager.get_hit);
        rb.linearVelocity = dir.normalized * -knockback;
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        player.toggleDamaged();
        yield return new WaitForSeconds(duration);
        player.toggleDamaged();
    }
}
