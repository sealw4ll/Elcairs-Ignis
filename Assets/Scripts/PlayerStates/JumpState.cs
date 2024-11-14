using UnityEngine;

public class JumpState : PlayerState
{
    public float velocityThreshold = 0.1f;
    public JumpLeftState jumpLeftState;
    public JumpRightState jumpRightState;
    public JumpIdleState jumpIdleState;

    public override void Do()
    {
        if (player.rb.linearVelocityX < -velocityThreshold)
        {
            Set(jumpLeftState);
        }
        else if (player.rb.linearVelocityX > velocityThreshold)
        {
            Set(jumpRightState);
        } else
        {
            Set(jumpIdleState);
        }

        if (player.groundSensor.isGrounded)
        {
            isComplete = true;
            return;
        }
    }
}
