using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Transform end;
    public Text score;
    public TextMeshProUGUI infoUI;
    public float distanceRemaining;

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<PlayerMovement>().shouldRun)
        {
            distanceRemaining = (end.position.z - player.position.z);
            if (player.position.z > 20 && distanceRemaining >= 0)
            {
                // If game is not over, write new distance
                // Otherwise, keep last score
                if (!FindObjectOfType<GameManager>().isGameOver)
                {
                    FindObjectOfType<Timer>().timer.text = "";
                    score.text = (distanceRemaining/10).ToString("0");
                }
            }
            else
            { // prevent score from showing negative number
                score.text = "";
            }
        }

        if (FindObjectOfType<GameManager>().isGameOver)
            infoUI.text = "Game Over";
    }
}
