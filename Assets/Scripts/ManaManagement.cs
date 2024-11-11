using System;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Speed {
    public float runSpeed;
    public float runAcceleration;
    public float dashSpeed;
    public float jumpSpeed;
}

public class ManaManagement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private uint manaCount;
    public uint initialMana;
    public uint maxMana;

    [SerializeField] private healthBar manaBar;

    public Speed defaultSpeed = new Speed() { runSpeed = 8f, runAcceleration = 1f, dashSpeed = 24f, jumpSpeed = 10f };

    public Speed[] speeds = new Speed[0];

    void Start()
    {
        setMana(initialMana);
    }
    
    public void setMana(uint mana)
    {
        manaCount = Math.Clamp(mana, 0, maxMana);
        manaBar.UpdateHealthBar(manaCount, maxMana);
    }

    public void increaseMana(uint count)
    {
        setMana(manaCount + count);
    }

    public void decreaseMana(uint count)
    {
        setMana(manaCount - count);
    }

    public bool enoughMana(uint count) {
        return manaCount >= count;
    }

    public uint getCount() {
        return manaCount;
    }
    private Speed getSpeedData()
    {
        if (speeds.Length == 0 || manaCount == 0)
            return defaultSpeed;
        if (speeds.Length < manaCount)
            return speeds[speeds.Length - 1];
        return speeds[manaCount - 1];
    }

    public float getJumpSpeed()
    {
        return getSpeedData().jumpSpeed;
    }

    public float getDashSpeed()
    {
        return getSpeedData().dashSpeed;
    }

    public float getRunSpeed()
    {
        return getSpeedData().runSpeed;
    }

    public float getRunAcceleration()
    {
        return getSpeedData().runAcceleration;
    }
}
