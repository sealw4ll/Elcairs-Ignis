using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int damage = 3;
    public string targetTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetTag && collision.GetComponent<Health>() != null)
        {
            Health targetHP = collision.GetComponent<Health>();
            targetHP.dealDmg(damage, this.GetComponent<Rigidbody2D>());
        }
    }
}
