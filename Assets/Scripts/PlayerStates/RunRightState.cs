using UnityEngine;

public class RunRightState : PlayerState
{
    public float runningThreshold = 0.1f;

    public override void Enter()
    {
        base.Enter();
        playerAnim.Play("walkRight");
    }

    public override void Do()
    {
    }
}
