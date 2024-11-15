using UnityEngine;
using System.Collections;

public class vomitProjectile : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public Transform centerPos;
    public Transform rotation;
    public Animator anim;

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
        SceneController.instance.AudioManager.PlaySFX(SceneController.instance.AudioManager.enemy_shot);
        anim.Play("slime_attack");
        GameObject bulletChild = Instantiate(bullet, bulletPos.position, rotation.rotation);
        bulletBehavior bulletBehavior = bulletChild.GetComponent<bulletBehavior>();
        bulletBehavior.setDirection(bulletPos.position - centerPos.position);

        StartCoroutine(PlayIdleAfterDelay(0.3f));
    }

    private IEnumerator PlayIdleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        anim.Play("slime_idle");
    }
}