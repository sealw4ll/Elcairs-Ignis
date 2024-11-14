using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform atkCenter;
    [SerializeField] private GameObject attackArea = default;

    public bool attacking { get; protected set; } = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;
    private float xDir;
    private float yDir;

    public Vector2 lastDir = new Vector2(1, 0);
    public Vector2 curDir = new Vector2(1, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        /*
            if (Input.GetMouseButtonDown(0)) // TODO: Change Key 
            {
                xDir = Input.GetAxis("Horizontal");
                yDir = Input.GetAxis("Vertical");
                Attack();
            }
        */

        if (attacking)
        {
            timer += Time.deltaTime;
            if (timer >= timeToAttack)
            {
                Reset();
            }
        }
    }

    private void Reset()
    {
        timer = 0f;
        attacking = false;
        attackArea.SetActive(false);
    }

    public void Attack(float xDir, float yDir)
    {
        Vector2 direction = new Vector2(xDir, yDir);
        if (direction == Vector2.zero)
        {
            curDir = lastDir;
            atkCenter.rotation = Quaternion.FromToRotation(Vector3.up, lastDir);
        }
        else
        {
            if (xDir != 0)
            {
                lastDir = new Vector2(xDir, 0);
            }
            atkCenter.rotation = Quaternion.FromToRotation(Vector3.up, direction);
            curDir = direction;
        }

        attacking = true;
        attackArea.SetActive(true);
    }
}
