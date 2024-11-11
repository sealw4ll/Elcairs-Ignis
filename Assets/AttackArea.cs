using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int damage = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.tag == "Enemy" && collision.GetComponent<Health>() != null)
        {
            Debug.Log("Attacked An Enemy");
            Health targetHP = collision.GetComponent<Health>();
            targetHP.dealDmg(damage);
        }
    }
}
