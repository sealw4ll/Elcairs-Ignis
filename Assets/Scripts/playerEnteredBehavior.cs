using System.Diagnostics.Contracts;
using UnityEngine;

public class playerEnteredBehavior : MonoBehaviour
{
    private Transform target;
    public vomitProjectile gun;
    private bool playerWithin = false;
    private bool los = false;
    public LayerMask stageMask;

    public void setTarget(Transform target)
    {
        this.target = target;
        this.los = false;
    }

    public void Update()
    {
        if (playerWithin)
        {
            Vector2 direction = -1 * (target.position - transform.position);
            transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);

            if (Physics2D.Linecast(target.position, transform.position, stageMask))
                noLOS();
            else
                HaveLOS();
        }
    }

    public void HaveLOS()
    {
        this.los = true;
        gun.started = true;
    }

    public void noLOS()
    {
        this.los = false;
        gun.started = false;
    }

    public void playerEntered()
    {
        playerWithin = true;
    }

    public void playerExit()
    {
        playerWithin = false;
        noLOS();
    }
}
