using UnityEngine;

public class dashingManaRegen : MonoBehaviour
{
    public ManaManagement manaStore;
    private int regenCount = 1;

    public int damage = 3;
    public string targetTag;

    private void OnEnable()
    {
        regenCount = 1;
    }

    private void OnDisable()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            if (regenCount > 0)
            {
                manaStore.increaseMana(1);
                regenCount--;
            }

            // onRush moment
            Health targetHP = collision.GetComponent<Health>();
            if (targetHP != null) { 
                targetHP.dealDmg(damage, this.GetComponent<Rigidbody2D>());
            }
        }
    }
}
