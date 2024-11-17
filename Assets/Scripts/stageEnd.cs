using UnityEngine;

public class stageEnd : MonoBehaviour
{
    [SerializeField] private string playerTag;
    [SerializeField] private string playerDashTag;

    public NextScene nextScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == playerTag || collision.gameObject.tag == playerDashTag)
        {
            endStage();
        }
    }

    private void endStage()
    {
        nextScene.Result();
    }
}
