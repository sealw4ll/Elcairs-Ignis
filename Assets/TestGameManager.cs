using UnityEngine;

public class TestGameManager : MonoBehaviour
{
    public playerScript player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && player.dead)
        {
            player.resetPlayer();
        }
    }
}
