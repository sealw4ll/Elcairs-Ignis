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
            Set(attackState);
        }
        else if (player.isDashing)
        {
            Set(dashState);
        }
        else if (Mathf.Abs(player.rb.linearVelocityX) >= runState.runningThreshold)
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
