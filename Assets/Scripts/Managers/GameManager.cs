using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 3f;

    public GameObject completeLevelUI;
    public GameObject pauseLevelUI;
    public bool isGameOver = false;
    public bool isInfiniteMode = false;

    private bool isPaused = false;

    // Keys
    public KeyCode leftKey { get; set; }
    public KeyCode rightKey { get; set; }

    private void Awake()
    {
        // FIXME : reset on every scene - a singleton would be better but causes bugs
        leftKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(Constants.LEFT_KEY_NAME, Constants.LEFT_KEY_DEFAULT_VALUE));
        rightKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(Constants.RIGHT_KEY_NAME, Constants.RIGHT_KEY_DEFAULT_VALUE));
    }

    public void GameOver()
    {
        // Call Restart() after x time in seconds
        isGameOver = true;
        if (isInfiniteMode)
            WriteBestScore((int)FindObjectOfType<PlayerMovement>().transform.position.z/10);
        Invoke("Restart", restartDelay);
    }

    public void GameWin()
    {
        FindObjectOfType<PlayerMovement>().shouldRun = false;
        completeLevelUI.SetActive(true);
        
    }

    public void PauseGame()
    {
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        Timer timer = FindObjectOfType<Timer>();

        isPaused = !isPaused;

        // Show or Unshow the pause UI
        pauseLevelUI.SetActive(isPaused);

        // Pause or Resume start timer
        if (isPaused)
            timer.StopTimer();
        else
            timer.StartTimer();

        // Keep player velocity only if game is paused
        if (isPaused)
            playerMovement.playerV3 = playerMovement.rb.velocity;

        // Stop player movements and input listening
        if(isPaused)
            playerMovement.shouldRun = false;
        
        // Pause Gravity on pause (prevent flying player from falling
        playerMovement.rb.useGravity = isPaused ? false:true;

        // If game is paused, stop Z player velocity (forward)
        // If game is unpaused, set back player velocity
        playerMovement.rb.velocity = isPaused ? new Vector3(0, 0, 0) : playerMovement.playerV3;
    }

    public void Restart()
    {
        FindObjectOfType<PlayerMovement>().shouldRun = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        FindObjectOfType<Timer>().StartTimer();
    }

    private void WriteBestScore(int score)
    {
        if(score > PlayerPrefs.GetInt(Constants.BEST_SCORE))
            PlayerPrefs.SetInt(Constants.BEST_SCORE, score);
    }
}
