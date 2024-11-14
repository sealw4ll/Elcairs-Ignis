using UnityEngine;

public class regenAllIgnis : MonoBehaviour
{
    public void regen()
    {
        foreach (Transform child in transform)
        {
            GameObject g = child.gameObject;
            CollectibleRegen collectibleRegen = g.GetComponent<CollectibleRegen>();

            if (collectibleRegen != null) {
                collectibleRegen.regenPickup();
            }
        }
    }
}
