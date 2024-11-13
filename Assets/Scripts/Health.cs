using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int hp;
    [SerializeField] private int maxHp;
    [SerializeField] private healthBar hpBar = null;
    [SerializeField] private damagedBehaviour damaged = null;
    [SerializeField] private ManaManagement mana = null;
    [SerializeField] private OnDeath deathManager = null;

    private void Awake()
    {
        hp = maxHp;
        if (hpBar != null )
        {
            hpBar.UpdateHealthBar(hp, maxHp);
        }
    }

    public void dealDmg(int dmgCount, Rigidbody2D collided)
    {
        int remainder = dmgCount;
        if (mana != null)
        {
            int manaCount = mana.getCount();
            remainder = dmgCount - manaCount;
            mana.decreaseMana(dmgCount);
        }

        if (hp > 0 && remainder > 0)
        {
            hp = Math.Clamp(hp - remainder, 0, maxHp);
            if (hpBar != null)
            {
                hpBar.UpdateHealthBar(hp, maxHp);
            }
        }

        if (damaged != null)
        {
            damaged.playDamaged(collided);
        }

        if (isDead() && deathManager != null)
        {
            deathManager.killEntity();
        }
    }

    public bool isDead()
    {
        return hp <= 0;
    }
}
