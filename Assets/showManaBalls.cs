using UnityEngine;

public class showManaBalls : MonoBehaviour
{
    public BoxCollider2D area;
    public Transform spawnLoc;
    public ManaManagement mana;
    public GameObject manaBalls;
    private GameObject[] balls;

    private void Awake()
    {
        balls = new GameObject[mana.maxMana];
    }

    public void UpdateHealthBar(int cur)
    {
        foreach (GameObject b in balls) {
            if (b != null) { 
                Destroy(b);
            }
        }

        float distance = area.size.x / (cur - 1 + 2);
        float center = area.size.y / 2;

        for (int i = 0; i < cur; i++)
        {
            GameObject newBalls = Instantiate(manaBalls, spawnLoc, worldPositionStays: false);
            newBalls.transform.localPosition += new Vector3(distance * (i + 1), 0);
            balls[i] = newBalls;
        }
    }
}
