using System.Collections;
using UnityEngine;

public class killZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnDeath player = other.gameObject.GetComponent<playerOnDeath>();
            player.killEntity();
        }
    }
}
