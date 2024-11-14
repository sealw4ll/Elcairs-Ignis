using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;

    public int savedMana = 1;

    public playerScript PlayerScript;

    public float resTime = 3f;

    public void changeSavedMana(int newVal)
    {
        savedMana = newVal;
        if (newVal <= 0)
        {
            savedMana = 1;
        }
    }

    public void TriggerRespawn()
    {
        StartCoroutine(CountdownRespawn());
    }

    public IEnumerator CountdownRespawn()
    {
        yield return new WaitForSeconds(resTime);
        RespawnFunc();
    }

    public void RespawnFunc()
    {
        Vector3 newPosition = respawnPoint.transform.position;
        newPosition.z = 0;
        ResetScene();
        player.transform.position = newPosition;
        PlayerScript.resetPlayer();
        ManaManagement manaManagement = player.GetComponent<ManaManagement>();
        manaManagement.setMana(savedMana);
    }

    public regenAllIgnis manaOrbs;
    public RegenAllEnemies enemies;

    public void ResetScene()
    {
        manaOrbs.regen();
        enemies.regen();

        /*
        Debug.Log("Regenerating Scene");

        GameObject []enemies = GameObject.FindGameObjectsWithTag("Enemy");
        List<GameObject> collectibles = GetChildrenWithTag(manaOrbs, "Collectibles");

        Debug.Log(enemies);
        Debug.Log(collectibles);

        foreach (GameObject enemy in enemies)
        {
            enemyReset reseter = enemy.GetComponent<enemyReset>();
            if (reseter != null)
                reseter.EnemyReset();
        }

        foreach (GameObject collect in collectibles) {
            CollectibleRegen reseter = collect.GetComponent<CollectibleRegen>();
            if (reseter != null)
                reseter.regenPickup();
        }
        */
    }
}
