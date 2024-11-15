using System.Collections;
using UnityEngine;

public class killZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneController.instance.AudioManager.PlaySFX(SceneController.instance.AudioManager.player_die_lava);
            playerOnDeath player = other.gameObject.GetComponent<playerOnDeath>();
            player.killEntity();
        }
    }
}
