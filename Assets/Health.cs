using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int hp;
    [SerializeField] private int maxHp;
    [SerializeField] private healthBar hpBar = null;

    private void Awake()
    {
        hp = maxHp;
        if (hpBar != null )
        {
            hpBar.UpdateHealthBar(hp, maxHp);
        }
    }

    public void dealDmg(int dmgCount)
    {
        if (hp > 0)
        {
            hp = Math.Clamp(hp - dmgCount, 0, maxHp);
            if (hpBar != null)
            {
                hpBar.UpdateHealthBar(hp, maxHp);
            }
        }

        if (isDead())
        {
            Debug.Log("You died bozo");
        }
    }

    public bool isDead()
    {
        return hp <= 0;
    }
}
