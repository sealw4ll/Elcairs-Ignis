using UnityEngine;

public class IdleState : PlayerState
{
    public override void Do()
    {
        // Debug.Log("Idle");
        if (!player.isIdle())
        {
            isComplete = true;
        }
    }
}
