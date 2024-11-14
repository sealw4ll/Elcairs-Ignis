using UnityEngine;

public class GroundSensor : MonoBehaviour {
    [SerializeField] private BoxCollider2D feetCollider;
    [SerializeField] private LayerMask groundLayer;

    public bool isGrounded;

    void Update() {
        CheckGrounded();
    }

    public void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapAreaAll(feetCollider.bounds.min, feetCollider.bounds.max, groundLayer).Length > 0;
    }
}