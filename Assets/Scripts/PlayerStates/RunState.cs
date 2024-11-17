using UnityEngine;

public class RunState : PlayerState
{
    public RunLeftState runLeftState;
    public RunRightState runRightState;

    public float runningThreshold = 0.1f;

    public override void Do()
    {
        // Debug.Log("Running");
        if (player.horizontalInput < 0)
        {
            Set(runLeftState);
        }
        else
        {
            Set(runRightState);
        }

        if (!groundSens.isGrounded || Mathf.Abs(player.rb.linearVelocityX) < runningThreshold || player.horizontalInput == 0)
        {
            isComplete = true;
        }
    }
}
