using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    private void OnTriggerStay2D(Collider2D collision)
    {
        // player HITBOX and walls
        if (collision.gameObject.layer == 6 || 
            collision.gameObject.layer == 7
            )
            Destroy(this.gameObject);

        if (collision.gameObject.tag == "PlayerAttack")
            SceneController.instance.AudioManager.PlaySFX(SceneController.instance.AudioManager.projectile_clash);
    }

    public void setDirection(Vector3 dir)
    {
        rb.linearVelocity = dir.normalized * speed; 
    }
}
