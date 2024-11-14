using UnityEngine;

public class RunLeftState : PlayerState
{
    public float runningThreshold = 0.1f;

    public override void Enter()
    {
        base.Enter();
        playerAnim.Play("walkLeft");
    }

    public override void Do()
    {
    }
}
