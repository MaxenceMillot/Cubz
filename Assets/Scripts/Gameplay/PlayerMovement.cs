using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public bool shouldRun = false;
    public bool isUnstopable = false;
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
    }
    void FixedUpdate()
    {
       
        if (shouldRun)
        {
            // Used to give more spinning
            //rb.maxAngularVelocity = 10;

            // Add a forward force
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);

            if (Input.GetKey(FindObjectOfType<GameManager>().rightKey))
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

            if (Input.GetKey(FindObjectOfType<GameManager>().leftKey))
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }


}
