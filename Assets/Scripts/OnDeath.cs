using UnityEngine;

public abstract class OnDeath : MonoBehaviour
{
    public virtual void killEntity()
    {
        Debug.Log("You Died!");
    }
}
