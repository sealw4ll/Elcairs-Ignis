using UnityEngine;

public class DeadState : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        playerAnim.Play("death");
    }

    public override void Do()
    {
        base.Do();
        if (!player.dead)
        {
            isComplete = true;
        }
    }
}
