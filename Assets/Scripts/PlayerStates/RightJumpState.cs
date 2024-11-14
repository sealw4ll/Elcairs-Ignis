using UnityEngine;

public class JumpRightState : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        playerAnim.Play("airRight");
    }
}
