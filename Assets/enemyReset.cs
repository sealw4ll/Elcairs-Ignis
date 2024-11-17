using UnityEngine;

public class enemyReset : MonoBehaviour
{
    public Health enemyHealth;
    public void EnemyReset()
    {
        this.gameObject.SetActive(true);
        this.GetComponent<playerEnteredBehavior>().enabled = true;
        this.gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        enemyHealth.regen();
    }
}
