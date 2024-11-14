using UnityEngine;

public class DeadState : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        playerAnim.Play("death");
    }
}
