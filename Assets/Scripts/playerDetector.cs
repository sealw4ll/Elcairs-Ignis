using UnityEngine;

public class playerDetector : MonoBehaviour
{
    [SerializeField] private string playerTag;
    [SerializeField] playerEnteredBehavior behavior;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            behavior.setTarget(collision.gameObject.transform);
            behavior.playerEntered();
        }        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == playerTag)
            behavior.playerExit();
    }
}
