using UnityEngine;

public class playerOnDeath : OnDeath
{
    public GameObject playerObj;
    public playerScript player;
    public RespawnScript respawner;

    private void Reset()
    {
    }

    private void Update()
    {
    }

    public void AnimationDoneAction()
    {
        player.dead = true;
        playerObj.SetActive(false);
        Debug.Log("SomethingSomething");
        respawner.RespawnFunc();
    }

    public override void killEntity()
    {
        Debug.Log("You Died!");
        player.dying = true;
    }
}
