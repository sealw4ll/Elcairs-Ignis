using UnityEngine;

public class RunState : PlayerState
{
    public RunLeftState runLeftState;
    public RunRightState runRightState;

    public float runningThreshold = 0.1f;

    public override void Do()
    {
        // Debug.Log("Running");
        if (player.rb.linearVelocityX < 0 || player.horizontalInput < 0)
        {
            Set(runLeftState);
        }
        else
        {
            Set(runRightState);
        }

        if (!groundSens.isGrounded || Mathf.Abs(player.rb.linearVelocityX) < runningThreshold )
        {
            isComplete = true;
        }
    }
}
