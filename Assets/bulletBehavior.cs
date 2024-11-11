using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        Destroy(this.gameObject);
    }

    private void Start()
    {
    }

    public void setDirection(Vector3 dir)
    {
        rb.linearVelocity = dir.normalized * speed; 
    }
}
