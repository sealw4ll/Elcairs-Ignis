using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public GameObject point;
    private RespawnScript respawn;
    private BoxCollider2D checkpoint;
    private SpriteRenderer icon;
    public Sprite active;

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
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("PlayerDashing"))
        {
            respawn.respawnPoint = point;
            icon.sprite = active;
            checkpoint.enabled = false;
        }
    }
}
