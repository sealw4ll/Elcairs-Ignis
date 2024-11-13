using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    private RespawnScript respawn;
    private BoxCollider2D checkpoint;
    private SpriteRenderer icon;
    public Sprite passive, active;

    void Awake()
    {
        checkpoint = GetComponent<BoxCollider2D>();
        respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnScript>();
        icon = GetComponent<SpriteRenderer>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            respawn.respawnPoint = this.gameObject;
            icon.sprite = active;
            checkpoint.enabled = false;
        }
    }
}
