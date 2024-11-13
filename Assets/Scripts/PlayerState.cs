using UnityEngine;

public abstract class PlayerState : State
{
    protected Animator playerAnim;
    protected playerScript player;
    public GroundSensor groundSens => player.groundSensor;

    public void SetUp(playerScript player, Animator playerAnim)
    {
        this.player = player;
        this.playerAnim = playerAnim;
    }
}
