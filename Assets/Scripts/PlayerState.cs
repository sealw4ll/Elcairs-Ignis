using UnityEngine;

public abstract class PlayerState : State
{
    protected playerScript player;
    public GroundSensor groundSens => player.groundSensor;

    public void SetUp(playerScript player)
    {
        this.player = player;
    }
}
