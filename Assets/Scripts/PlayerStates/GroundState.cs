using UnityEngine;

public class GroundState : PlayerState
{
    public PlayerAttack playerAtk;

    public IdleState idleState;
    public RunState runState;
    public DashState dashState;
    public AttackState attackState;

    public override void Do()
    {
        if (playerAtk.attacking)
        {
            Set(attackState, true);
        }
        else if (player.isDashing)
        {
            Set(dashState);
        }
        else if (
            Mathf.Abs(player.rb.linearVelocityX) >= runState.runningThreshold || 
            Mathf.Abs(player.horizontalInput) > 0
            )
        {
            Set(runState);
        }
        else
        {
            Set(idleState);
        }

        if (!groundSens.isGrounded)
        {
            isComplete = true;
        }
    }
}
