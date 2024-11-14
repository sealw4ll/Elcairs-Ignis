using UnityEngine;

public class effectBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject parent;

    public void removeSelf()
    {
        Destroy(parent);
    }
}
