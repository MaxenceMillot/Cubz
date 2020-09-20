using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreReversed : MonoBehaviour
{
    public Transform player;
    public Text score;
    public Text bestScore;
    public TextMeshProUGUI infoUI;

    private float distance;

    private void Start()
    {
        // Get and write Best score
        bestScore.text += PlayerPrefs.GetInt(Constants.BEST_SCORE);

    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<PlayerMovement>().shouldRun)
        {
            distance = player.position.z;
            if (distance > 20 )
            {
                // If game is not over, write new distance
                // Otherwise, keep last score
                if (!FindObjectOfType<GameManager>().isGameOver)
                {
                    FindObjectOfType<Timer>().timer.text = "";
                    score.text = (distance/10).ToString("0");
                }
            }
        }

        if (FindObjectOfType<GameManager>().isGameOver)
            infoUI.text = "Game Over";
    }
}
