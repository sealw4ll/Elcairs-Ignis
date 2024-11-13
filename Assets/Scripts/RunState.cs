using UnityEngine;

public class RunState : PlayerState
{
    public float runningThreshold = 0.1f;

    public override void Do()
    {
        // Debug.Log("Running");

        if (!groundSens.isGrounded || Mathf.Abs(player.rb.linearVelocityX) < runningThreshold )
        {
            isComplete = true;
        }
    }

}
