using System;
using UnityEngine;

public class ManaManagement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private uint manaCount;
    public uint initialMana;
    public uint maxMana;

    void Start()
    {
        manaCount = initialMana;
    }
    
    public void setMana(uint mana)
    {
        manaCount = Math.Clamp(mana, 0, maxMana);
    }

    public void increaseMana(uint count)
    {
        setMana(manaCount + count);
    }

    public void decreaseMana(uint count)
    {
        setMana(manaCount - count);
    }

    public uint getCount(uint count) {
        return manaCount;
    }
}
