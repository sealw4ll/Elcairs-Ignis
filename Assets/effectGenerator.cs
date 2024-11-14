using UnityEngine;

public class EffectGenerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject jumpEffect;
    public Transform loc;

    public void generate()
    {
        Instantiate(jumpEffect, loc.position, Quaternion.identity); 
    }
}
