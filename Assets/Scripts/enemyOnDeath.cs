using UnityEngine;

public class enemyOnDeath : OnDeath
{
    public override void killEntity()
    {
        Destroy(this.gameObject);
    }
}
