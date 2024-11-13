using UnityEngine;

public class DashState: PlayerState
{
    public override void Do()
    {
        // Debug.Log("Dashing");
        if (!player.isDashing) {
            isComplete = true;
        }
    }
}
