using UnityEngine;

public class playerOnDeath : OnDeath
{
    public override void killEntity()
    {
        Debug.Log("You Died!");
    }
}
