using UnityEngine;

public class enemyOnDeath : OnDeath
{
    public override void killEntity()
    {
        this.gameObject.SetActive(false);
    }
}
