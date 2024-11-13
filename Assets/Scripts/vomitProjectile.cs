using UnityEngine;

public class vomitProjectile : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public Transform centerPos;
    public Transform rotation;

    public bool started = false;

    private float timer;
    public float cooldown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!started) return;

        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            timer = 0;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bulletChild = Instantiate(bullet, bulletPos.position, rotation.rotation);
        bulletBehavior bulletBehavior = bulletChild.GetComponent<bulletBehavior>();
        bulletBehavior.setDirection(bulletPos.position - centerPos.position);
    }
}