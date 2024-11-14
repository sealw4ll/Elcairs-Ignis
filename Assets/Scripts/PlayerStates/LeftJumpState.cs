using UnityEngine;

public class JumpLeftState : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        playerAnim.Play("airLeft");
    }
}
