using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;

    public int savedMana = 1;

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
           ManaManagement manaManagement = other.gameObject.GetComponent<ManaManagement>();
            manaManagement.setMana(savedMana);
            player.transform.position = respawnPoint.transform.position;
        }
    }
}
