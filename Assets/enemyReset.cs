using UnityEngine;

public class enemyReset : MonoBehaviour
{
    public Health enemyHealth;
    public vomitProjectile vomitProjectile;

    public void EnemyReset()
    {
        this.gameObject.SetActive(true);
        // tf, did i type this?
        this.GetComponent<playerEnteredBehavior>().enabled = true;
        this.gameObject.GetComponent<CapsuleCollider2D>().enabled = true;

        if (vomitProjectile)
        {
            vomitProjectile.removeBullets();
        }
        enemyHealth.regen();
    }
}
