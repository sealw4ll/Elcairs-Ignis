using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public uint damage = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>() != null)
        {
            Health targetHP = collision.GetComponent<Health>();
            targetHP.dealDmg(damage);
        }
    }
}
