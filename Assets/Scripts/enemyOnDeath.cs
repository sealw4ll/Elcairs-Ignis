using UnityEngine;
using System.Collections;

public class enemyOnDeath : OnDeath
{
    public Animator anim;

    public override void killEntity()
    {
        this.GetComponent<CapsuleCollider2D>().enabled = false;
        anim.Play("slime_death");
        StartCoroutine(PlayIdleAfterDelay(0.4f));
    }

    private IEnumerator PlayIdleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        this.gameObject.SetActive(false);
    }
}
