using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public GameObject point;
    public RespawnScript respawn;
    private BoxCollider2D checkpoint;
    private SpriteRenderer icon;
    private ManaManagement playerMana;
    public Sprite active;
    public GameObject lightObject;
    public GameObject particlesObject;

    public float savedMana = 1f;

    void Awake()
    {
        checkpoint = GetComponent<BoxCollider2D>();
        icon = GetComponent<SpriteRenderer>();
        playerMana = GameObject.FindGameObjectWithTag("Player").GetComponent<ManaManagement>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("PlayerDashing"))
        {
            respawn.respawnPoint = point;
            respawn.changeSavedMana(playerMana.getCount());
            icon.sprite = active;
            lightObject.SetActive(true);
            particlesObject.SetActive(true);
            checkpoint.enabled = false;
        }
    }
}
