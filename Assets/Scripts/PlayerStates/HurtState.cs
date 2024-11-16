using UnityEngine;

public class HurtState: PlayerState
{
    public SpriteRenderer sprite;
    Color inital;

    public override void Enter()
    {
        base.Enter();
        inital = sprite.color;
        sprite.color = Color.red;
    }

    public override void Do()
    {
        // Debug.Log("Hurt");
        if (!player.damaged)
        {
            isComplete = true;
        }
    }

    public override void Exit()
    {
        base.Exit();
        sprite.color = inital;
    }
}
