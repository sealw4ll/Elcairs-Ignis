using UnityEngine;

public class playerOnDeath : OnDeath
{
    public GameObject playerObj;
    public playerScript player;
    public RespawnScript respawner = null;

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
        if (respawner != null)
        {
            respawner.TriggerRespawn();
        }
    }

    public override void killEntity()
    {
        Debug.Log("You Died!");
        player.dying = true;
        player.rb.linearVelocity = new Vector2(0, 0);
        player.rb.gravityScale = 0;
    }
}
