using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    public GameObject keysHelp;
    public Text leftKey;
    public Text rightKey;
    public float targetTime = 3.0f;

    public bool shouldCount = false;

    private void Start()
    {
        string textLeft = FindObjectOfType<GameManager>().leftKey.ToString();
        string textRight = FindObjectOfType<GameManager>().rightKey.ToString();

        leftKey.text = textLeft;
        if (textLeft.Length > 3)
            leftKey.fontSize = 22;

        rightKey.text = textRight;
        if (textRight.Length > 3)
            rightKey.fontSize = 22;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldCount)
        {
            targetTime -= Time.deltaTime;
            if (targetTime <= 1.0f)
            {
                timer.text = "Go !";
                shouldCount = false;
                FindObjectOfType<PlayerMovement>().shouldRun = true;
            }
            else
            {
                timer.text = targetTime.ToString("0");
            }
        }

        // Hide Keys help after a distance
        if (FindObjectOfType<PlayerMovement>().transform.position.z > 200)
            keysHelp.SetActive(false);
    }

    public void StartTimer()
    {
        shouldCount = true;
    }

    public void StopTimer()
    {
        shouldCount = false;
    }
}
