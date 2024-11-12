using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int hp;
    [SerializeField] private int maxHp;
    [SerializeField] private healthBar hpBar = null;
    [SerializeField] private damagedBehaviour damaged = null;
    [SerializeField] private ManaManagement mana = null;

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
        int manaCount = 0;
        int remainder = dmgCount;
        if (mana != null)
        {
            manaCount = mana.getCount();
            remainder = dmgCount - manaCount;
            mana.decreaseMana(dmgCount);

            if (remainder <= 0)
                return;
        }

        if (hp > 0)
        {
            hp = Math.Clamp(hp - remainder, 0, maxHp);
            if (hpBar != null)
            {
                hpBar.UpdateHealthBar(hp, maxHp);
            }
            if (damaged != null)
            {
                damaged.playDamaged();
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
