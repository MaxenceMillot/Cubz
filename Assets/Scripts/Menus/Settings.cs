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

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
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
}
