using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private uint hp;

    public void dealDmg(uint dmgCount)
    {
        if (hp > 0)
        {
            hp -= dmgCount;
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
