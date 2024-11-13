using UnityEngine;

public class AirState : PlayerState
{
    public JumpState jumpState;
    public DashState dashState;

    public override void Do()
    {
        if (player.isDashing)
        {
            Set(dashState);
        }
        else
        {
            Set(jumpState);
        }

        if (groundSens.isGrounded) {
            isComplete = true;
        }
    }
}
