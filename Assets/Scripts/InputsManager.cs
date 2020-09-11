using UnityEngine;

public class InputsManager : MonoBehaviour
{
    // Singleton
    //public static InputsManager instance;

    // Keys
    public KeyCode leftKey { get; set; }
    public KeyCode rightKey { get; set; }
    private void Start()
    {
        // Singleton pattern
        // FIXME : Singleton cause infinite realod after fall gameover and win
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //    return;
        //}

        /*
        * Assign each keycode when the game starts.
        * Loads data from PlayerPrefs so if a user quits the game,
        * their bindings are loaded next time. Default values
        * are assigned to each Keycode via the second parameter
        * of the GetString() function
        */
        leftKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(Constants.LEFT_KEY_NAME, Constants.LEFT_KEY_DEFAULT_VALUE));
        rightKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(Constants.RIGHT_KEY_NAME, Constants.RIGHT_KEY_DEFAULT_VALUE));
    }
}

