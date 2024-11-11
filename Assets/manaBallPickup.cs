using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class manaBallPickup : MonoBehaviour
{
    public Collider2D playerDetector;
    private bool playerEnter = false;
    private bool keyHeldDown = false;
    private float timeHeld;
    public float timetoHold;
    public ManaManagement playerMana;
    private Vector3 oriScale;
    public Scaler manaSpriteScaler;

    private void Awake()
    {
        playerMana = GameObject.FindGameObjectWithTag("Player").GetComponent<ManaManagement>();
        oriScale = manaSpriteScaler.getCurrentScale();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void deleteSelf()
    {
        playerMana.increaseMana(1);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerEnter && Input.GetKeyDown(KeyCode.E)) // TODO: Change the value of this key
        {
            keyHeldDown = true;
        }
        else if (playerEnter && Input.GetKeyDown(KeyCode.E))
        {
            ResetCountdown();
        }

        if (keyHeldDown)
        {
            timeHeld += Time.deltaTime;
            manaSpriteScaler.setCurrentScale(oriScale * (1 - (timeHeld / timetoHold)));
            if (timeHeld > timetoHold)
            {
                deleteSelf();
            }
        }
    }

    private void ResetCountdown()
    {
        timeHeld = 0;
        keyHeldDown = false;
        manaSpriteScaler.setCurrentScale(oriScale);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Enter");
            playerEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Left");
            playerEnter = false;
            ResetCountdown();
        }
    }
}
