using UnityEngine;

public class stageEnd : MonoBehaviour
{
    [SerializeField] private string playerTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            endStage();
        }
    }

    private void endStage()
    {
        Debug.Log("Stage has ended");
    }
}
