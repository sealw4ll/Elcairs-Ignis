using System.Collections;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnDeath player = other.gameObject.GetComponent<playerOnDeath>();
            player.killEntity();
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
        player.transform.position = newPosition;
        PlayerScript.resetPlayer();
        ManaManagement manaManagement = player.GetComponent<ManaManagement>();
        manaManagement.setMana(savedMana);
    }
}
