using UnityEngine;

public class playerEnteredBehavior : MonoBehaviour
{
    private Transform target;
    public vomitProjectile gun;
    public bool playerWithin = false;

    public void setTarget(Transform target)
    {
        this.target = target;
    }

    public void Update()
    {
        if (playerWithin)
        {
            Vector2 direction = -1 * (target.position - transform.position);
            transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        }
    }

    public void playerEntered()
    {
        playerWithin = true;
        gun.started = true;
    }

    public void playerExit()
    {
        playerWithin = false;
        gun.started = false;
    }
}
