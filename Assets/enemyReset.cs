using UnityEngine;

public class enemyReset : MonoBehaviour
{
    public Health enemyHealth;
    public void EnemyReset()
    {
        this.gameObject.SetActive(true);
        enemyHealth.regen();
    }
}
