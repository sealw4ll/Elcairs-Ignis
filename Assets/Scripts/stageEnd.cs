using UnityEngine;

public class stageEnd : MonoBehaviour
{
    [SerializeField] private string playerTag;

    public NextScene nextScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            endStage();
        }
    }

    private void endStage()
    {
        nextScene.Result();
    }
}
