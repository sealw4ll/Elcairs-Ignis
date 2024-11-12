using UnityEngine;

public class damagedBehaviour : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    public float knockback = 10f;

    public void playDamaged()
    {
        // note: due to how we set velocity to 0 if we are turing, this no longer works
        // potential fix: link damage to playerScript instead of the fuck is this
        // god should have used classes (properly)
        rb.linearVelocity = new Vector2 (-knockback * (Mathf.Sign(transform.localScale.x)), 0);
    }
}
