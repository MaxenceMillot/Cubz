using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 20000f;
    public float sidewaysForce = 75f;
    public bool shouldRun = false;
    public bool isUnstopable = false;
    public GameObject keysHelp;
    public float forwardSpeedMultiplicator = 1f;
    public Vector3 playerV3;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Timer>().StartTimer();
    }

    // Update handle inputs not related to physics
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
            FindObjectOfType<GameManager>().PauseGame();

        if (rb.position.y < 0f)
            FindObjectOfType<GameManager>().GameOver();

        if (!shouldRun)
            return;

        if (Input.GetKey("w"))
            FindObjectOfType<GameManager>().GameWin();

        if (Input.GetKey("x"))
            isUnstopable = !isUnstopable;

        // Hide Keys help after a distance
        if (FindObjectOfType<PlayerMovement>().transform.position.z > 50)
            keysHelp.SetActive(false);
    }
    void FixedUpdate()
    {
        if (!shouldRun)
            return;

        // Used to give more spinning - unused
        //rb.maxAngularVelocity = 10;

        // Add a forward force
        rb.AddForce(0, 0, (forwardForce * forwardSpeedMultiplicator) * Time.deltaTime);

        if (Input.GetKey(FindObjectOfType<GameManager>().rightKey))
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (Input.GetKey(FindObjectOfType<GameManager>().leftKey))
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
}
