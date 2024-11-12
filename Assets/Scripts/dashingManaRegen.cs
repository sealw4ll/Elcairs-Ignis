using UnityEngine;

public class dashingManaRegen : MonoBehaviour
{
    public ManaManagement manaStore;
    private int regenCount = 1;

    public int damage = 3;
    public string targetTag;

    private void OnEnable()
    {
        Debug.Log("hello?");
        regenCount = 1;
    }

    private void OnDisable()
    {
        Debug.Log("Dsiabled");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            if (regenCount > 0)
            {
                Debug.Log("Regen Mana");
                manaStore.increaseMana(1);
                regenCount--;
            }

            // onRush moment
            Health targetHP = collision.GetComponent<Health>();
            targetHP.dealDmg(damage, this.GetComponent<Rigidbody2D>());
        }
    }
}
