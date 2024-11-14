using UnityEngine;

public class AttackState: PlayerState
{
    public Animator slashAnimation;
    public PlayerAttack playerAtkStatus;

    public override void Enter()
    {
        base.Enter();
        slashAnimation.Play("Slash");
    }

    public override void Do()
    {
        // Debug.Log("Attack");
        if (!playerAtkStatus.attacking)
            isComplete = true;
    }
}
