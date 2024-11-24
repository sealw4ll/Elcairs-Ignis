using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int damage = 3;
    public string targetTag;

    public bool targetWithin = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetTag && collision.GetComponent<Health>() != null)
        {
            Health targetHP = collision.GetComponent<Health>();
            targetHP.dealDmg(damage, this.GetComponent<Rigidbody2D>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetTag && collision.GetComponent<Health>() != null)
        {
            Health targetHP = collision.GetComponent<Health>();
            targetHP.dealDmg(damage, this.GetComponent<Rigidbody2D>());
        }
    }
    */
}
