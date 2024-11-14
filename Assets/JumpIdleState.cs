using UnityEngine;

public class JumpIdleState : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        playerAnim.Play("airIdle");
    }
}
