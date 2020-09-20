using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Transform settingsMenu;
    public Slider generalVolumeSlider;
    public Text textWaiting;
    public Text textFeedback;
    public GameManager gameManager;

    private Event keyEvent;
    private Text buttonText;
    private KeyCode newKey;
    private bool isWaitingForKey;
    private bool ignoreSliderChange = false;

    public void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        isWaitingForKey = false;

        // We set text of buttons depending of KeyCode already existing for it
        // ex: if left is "Q", the button text will be "Q"
        for (int i = 0; i < settingsMenu.childCount; i++)
        {
            // TODO : optimise this by creating a list of child and fiding in array instead of a loop
            if (settingsMenu.GetChild(i).name == "ButtonLeft")
                settingsMenu.GetChild(i).GetComponentInChildren<Text>().text = gameManager.leftKey.ToString();
            else if (settingsMenu.GetChild(i).name == "ButtonRight")
                settingsMenu.GetChild(i).GetComponentInChildren<Text>().text = gameManager.rightKey.ToString();
        }

        // This boolean prevent OnValueChanged to trigger
        ignoreSliderChange = true;
        generalVolumeSlider.value = PlayerPrefs.GetFloat(Constants.GENERAL_VOLUME_NAME, AudioManager.instance.generalVolume);
        ignoreSliderChange = false;
    }

    private void OnGUI()
    {
        // Event created by user (click or keypress)
        keyEvent = Event.current;

        // Executes if a button gets pressed 
        // AND the user presses a key 
        if (isWaitingForKey && keyEvent.isKey)
        {
            //Assigns newKey to the key user presses
            newKey = keyEvent.keyCode;
            isWaitingForKey = false;
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartAssignment(string keyName)
    {
        if (!isWaitingForKey)
            StartCoroutine(AssignKey(keyName));
    }

    public void ChangeGeneralVolume()
    {
        // Checking if should ignore, see "generalVolumeSlider.value" in Start()
        if (!ignoreSliderChange)
        {
            PlayerPrefs.SetFloat(Constants.GENERAL_VOLUME_NAME, generalVolumeSlider.value);
            AudioManager.instance.ChangeGeneralVolume(generalVolumeSlider.value);
        }
    }

    // Assigns buttonText to the text component of
    // the button that was pressed
    public void SendText(Text text)
    {
        buttonText = text;
    }

    //Used for controlling the flow of our below Coroutine
    IEnumerator WaitForKey()
    {
        // Wait while there is no key inputed 
        // or while key inputed is already set
        // while (!keyEvent.isKey || (keyEvent.keyCode == GameManager.instance.leftKey || keyEvent.keyCode == GameManager.instance.rightKey))
        while (isWaitingForKey)
        {
            yield return null;
        }
    }

    /*
    * AssignKey takes a keyName as a parameter. The
    * keyName is checked in a switch statement. Each
    * case assigns the command that keyName represents
    * to the new key that the user presses, which is grabbed
    * in the OnGUI() function, above.
    */
    public IEnumerator AssignKey(string keyName)
    {
        isWaitingForKey = true;

        textWaiting.text = "Press a new key to assign";

        // Executes endlessly until user presses a key
        yield return WaitForKey();

        switch (keyName)
        {
            case Constants.LEFT_KEY_NAME:
                //set left to new keycode
                gameManager.leftKey = newKey;
                //set button text to new key
                buttonText.text = gameManager.leftKey.ToString();
                //save new key to playerprefs
                PlayerPrefs.SetString(Constants.LEFT_KEY_NAME, gameManager.leftKey.ToString());
                EmptyUIFeedback();

                break;

            case Constants.RIGHT_KEY_NAME:
                //set right to new keycode
                gameManager.rightKey = newKey;
                //set button text to new key
                buttonText.text = gameManager.rightKey.ToString();
                //save new key to playerprefs
                PlayerPrefs.SetString(Constants.RIGHT_KEY_NAME, gameManager.rightKey.ToString());
                EmptyUIFeedback();

                break;
        }

        yield return null;
    }

    void EmptyUIFeedback()
    {
        textWaiting.text = textFeedback.text = "";
    }
}
