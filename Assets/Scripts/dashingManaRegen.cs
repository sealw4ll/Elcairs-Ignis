using UnityEngine;

public class dashingManaRegen : MonoBehaviour
{
    public ManaManagement manaStore;
    private int regenCount = 1;
    private void OnEnable()
    {
        regenCount = 1;
    }

    private void OnDisable()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            manaStore.increaseMana(1);
            regenCount--;
        }
    }
}
