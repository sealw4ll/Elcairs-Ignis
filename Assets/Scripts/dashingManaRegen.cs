using UnityEngine;

public class dashingManaRegen : MonoBehaviour
{
    public ManaManagement manaStore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
            manaStore.increaseMana(1);
    }
}
