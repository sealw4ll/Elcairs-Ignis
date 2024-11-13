using UnityEngine;

public class enemyReset : MonoBehaviour
{
    public Health enemyHealth;
    void EnemyReset()
    {
        this.gameObject.SetActive(true);
        enemyHealth.regen();
    }
}
