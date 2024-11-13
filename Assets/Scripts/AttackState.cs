using UnityEngine;

public class AttackState: PlayerState
{
    public PlayerAttack playerAtkStatus;

    public override void Do()
    {
        // Debug.Log("Attack");
        if (!playerAtkStatus.attacking)
            isComplete = true;
    }
}
