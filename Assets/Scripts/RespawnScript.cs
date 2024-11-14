using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;
    public playerScript PlayerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = respawnPoint.transform.position;
        }
    }

    public void RespawnFunc()
    {
        Vector3 newPosition = respawnPoint.transform.position;
        newPosition.z = 0;
        player.transform.position = newPosition;
        PlayerScript.resetPlayer();
    }
}
