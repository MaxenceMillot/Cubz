using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 3f;

    public GameObject completeLevelUI;

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
        Invoke("Restart", restartDelay);
    }

    public void GameWin()
    {
        FindObjectOfType<PlayerMovement>().shouldRun = false;
        completeLevelUI.SetActive(true);
    }

    void Restart()
    {
        FindObjectOfType<PlayerMovement>().shouldRun = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        FindObjectOfType<Timer>().StartTimer();
    }
}
