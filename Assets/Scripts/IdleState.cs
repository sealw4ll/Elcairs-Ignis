using UnityEngine;

public class IdleState : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        // 5% chance
        float percent = Random.Range(0f, 1f);
        if (percent < 0.05f)
            playerAnim.Play("idleSpecial");
        else
            playerAnim.Play("idle");
    }

    public override void Do()
    {
        // Debug.Log("Idle");
        if (!player.isIdle())
        {
            isComplete = true;
        }
    }
}
