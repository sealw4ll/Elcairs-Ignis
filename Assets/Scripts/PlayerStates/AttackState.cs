using UnityEngine;

public class AttackState: PlayerState
{
    public Animator slashAnimation;
    public PlayerAttack playerAtkStatus;

    public override void Enter()
    {
        base.Enter();

        if (playerAtkStatus.curDir.x < 0)
        {
            playerAnim.Play("lookLeft");
        }
        else if (playerAtkStatus.curDir.x == 0)
            playerAnim.Play("lookForward");
        else
        {
            playerAnim.Play("lookRight");
        }

        slashAnimation.Play("Slash");
    }

    public override void Do()
    {
        // Debug.Log("Attack");
        if (!playerAtkStatus.attacking)
            isComplete = true;
    }
}
