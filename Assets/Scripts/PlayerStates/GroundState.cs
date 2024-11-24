using UnityEngine;

public class GroundState : PlayerState
{
    public PlayerAttack playerAtk;

    public IdleState idleState;
    public RunState runState;
    public AttackState attackState;

    public override void Do()
    {
        if (playerAtk.attacking)
        {
            Set(attackState, true);
        }
        else if (
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
