using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class manaBallPickup : MonoBehaviour
{
    private ManaManagement playerMana;

    private void Awake()
    {
        playerMana = GameObject.FindGameObjectWithTag("Player").GetComponent<ManaManagement>();
    }

    void regenPickup()
    {
        // nice regen bro
        this.gameObject.SetActive(true);
    }

    void deactivateSelf()
    {
        playerMana.increaseMana(1);
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Test");
            deactivateSelf();
        }
    }
}
