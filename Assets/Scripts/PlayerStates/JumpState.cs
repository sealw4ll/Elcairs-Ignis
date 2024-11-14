using UnityEngine;

public class JumpState : PlayerState
{
    public override void Do()
    {
        // Debug.Log("Jumping");

        if (player.groundSensor.isGrounded)
        {
            isComplete = true;
            return;
        }
    }
}
