using UnityEngine;

public class HurtState: PlayerState
{
    public override void Do()
    {
        // Debug.Log("Hurt");
        if (!player.damaged)
        {
            isComplete = true;
        }
    }
}
