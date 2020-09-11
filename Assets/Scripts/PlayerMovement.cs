using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public bool shouldRun = false;
    public bool isUnstopable = false;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Timer>().StartTimer();
    }

    // Update is called once per frame
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

            if (Input.GetKey("w"))
                FindObjectOfType<GameManager>().GameWin();

            if (Input.GetKey("x"))
                isUnstopable = !isUnstopable;

            if (rb.position.y < 0f)
                FindObjectOfType<GameManager>().GameOver();

            // TODO : use this for pause menue
            //if (Input.GetKeyDown(KeyCode.Escape) && !settingsMenu.gameObject.activeSelf)
            //    settingsMenu.gameObject.SetActive(true);
            //else if (Input.GetKeyDown(KeyCode.Escape) && settingsMenu.gameObject.activeSelf)
            //    settingsMenu.gameObject.SetActive(false);
        }
    }


}
