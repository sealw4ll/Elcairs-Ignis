using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class manaBallPickup : MonoBehaviour
{
    private ManaManagement playerMana;

    private void Awake()
    {
        playerMana = GameObject.FindGameObjectWithTag("Player").GetComponent<ManaManagement>();
    }

    void deleteSelf()
    {
        playerMana.increaseMana(1);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            deleteSelf();
        }
    }
}
