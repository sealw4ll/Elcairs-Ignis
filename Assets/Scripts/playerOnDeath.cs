using UnityEngine;

public class playerOnDeath : OnDeath
{
    public GameObject playerObj;
    public playerScript player;

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
    }

    public override void killEntity()
    {
        Debug.Log("You Died!");
        player.dying = true;
    }
}
