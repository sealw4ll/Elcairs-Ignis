using UnityEngine;

public class manaBallProperties : MonoBehaviour
{
    public Transform sprite;
    public Vector2 start = new Vector2(0, -1);
    public Vector2 end = new Vector2(0, 1);

    private float speed;

    private void Start()
    {
        speed = Random.Range(0.5f, 1f);
    }

    private void Update()
    {
        sprite.localPosition = Vector2.MoveTowards(sprite.localPosition, end, Time.deltaTime * speed);
        if (Vector2.Distance(sprite.localPosition, end) < 0.05f)
        {
            Swap();
        }
    }

    private void Swap()
    {
        Vector2 temp = start;
        start = end;
        end = temp;
        speed = Random.Range(0.5f, 1f);
    }
}
