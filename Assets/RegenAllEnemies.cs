using UnityEngine;

public class RegenAllEnemies : MonoBehaviour
{
    public void regen()
    {
        foreach (Transform child in transform)
        {
            GameObject g = child.gameObject;
            enemyReset resetter = g.GetComponent<enemyReset>();

            if (resetter != null)
            {
                resetter.EnemyReset();
            }
        }
    }
}
