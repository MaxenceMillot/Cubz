using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Transform end;
    public Text score;
    public float distanceRemaining;

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<PlayerMovement>().shouldRun)
        {
            distanceRemaining = (end.position.z - player.position.z);
            if (player.position.z > 20 && distanceRemaining > 0)
            {
                FindObjectOfType<Timer>().timer.text = "";
                score.text = (distanceRemaining).ToString("0");
            }
            else
            { // prevent score from showing negative number
                score.text = "";
            }
        }
    }
}
