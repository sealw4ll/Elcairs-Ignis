using UnityEngine;
using System.Collections;

public class enemyOnDeath : OnDeath
{
    public Animator anim;

    public override void killEntity()
    {
        this.GetComponent<CapsuleCollider2D>().enabled = false;
        this.GetComponent<playerEnteredBehavior>().enabled = false;
        this.GetComponent<vomitProjectile>().StopGun();
        anim.Play("slime_death");
        SceneController.instance.AudioManager.PlaySFX(SceneController.instance.AudioManager.enemy_die);
        StartCoroutine(PlayIdleAfterDelay(0.4f));
    }

    private IEnumerator PlayIdleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        this.gameObject.SetActive(false);
    }
}
