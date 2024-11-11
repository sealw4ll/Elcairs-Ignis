using UnityEngine;

public class damagedBehaviour : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    public float knockback = 20f;

    public void playDamaged()
    {
        rb.linearVelocity = new Vector2 (-knockback * (Mathf.Sign(rb.linearVelocity.x)), rb.linearVelocity.y);
    }
}
