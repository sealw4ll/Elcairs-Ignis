using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // player HITBOX and walls
        if (collision.gameObject.layer == 6 || 
            collision.gameObject.layer == 7
            )
            Destroy(this.gameObject);

        if (collision.gameObject.tag == "PlayerAttack")
            SceneController.instance.AudioManager.PlaySFX(SceneController.instance.AudioManager.projectile_clash);
    }

    private void Start()
    {
    }

    public void setDirection(Vector3 dir)
    {
        rb.linearVelocity = dir.normalized * speed; 
    }
}
