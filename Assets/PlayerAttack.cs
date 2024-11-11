using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;

    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // TODO: Change Key 
        {
            Attack();
        }

        if (attacking)
        {
            timer += Time.deltaTime;
            if (timer >= timeToAttack)
            {
                Reset();
            }
        }
    }

    private void Reset()
    {
        timer = 0f;
        attacking = false;
        attackArea.SetActive(false);
    }

    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }
}
