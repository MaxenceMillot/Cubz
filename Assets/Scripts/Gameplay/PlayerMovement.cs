using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 10000f;
    public float sidewaysForce = 80f;
    public bool shouldRun = false;
    public bool isUnstoppable = false;
    public float defaultForwardSpeedMultiplicator = 1f;
    public float forwardSpeedMultiplicator = 1f;
    public float playerSpeedAfterCollision = 0.4f;
    public Vector3 playerV3;

    public bool shoudGoLeft = false;
    public bool shoudGoRight = false;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Timer>().StartTimer();
    }

    // Update handle inputs not related to physics
    private void Update()
    {
        if (rb.position.y < 0f)
            FindObjectOfType<GameManager>().GameOver();
    }
    void FixedUpdate()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (!shouldRun)
            return;

        // Used to give more spinning - unused
        //rb.maxAngularVelocity = 10;

        // If game is over, diminish forward speed
        forwardSpeedMultiplicator = gameManager.isGameOver ? playerSpeedAfterCollision : forwardSpeedMultiplicator;

        // Add a forward force
        rb.AddForce(0, 0, (forwardForce * forwardSpeedMultiplicator) * Time.deltaTime);

        // Don't listen to inputs if game is over
        if (gameManager.isGameOver)
            return;

        if(shoudGoLeft)
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if(shoudGoRight)
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
}
