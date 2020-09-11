using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public Text buttonMuteText;

    private void Start()
    {
        // Initialise Mute button
        bool isMuted = AudioManager.instance.isMuted;
        buttonMuteText.text = isMuted ? "Unmute" : "Mute";
    }

    public void ResumeGame()
    {
        FindObjectOfType<GameManager>().PauseGame();
    }

    public void RetryGame()
    {
        FindObjectOfType<GameManager>().Restart();
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void SwitchMute()
    {
        bool isMuted = AudioManager.instance.SwitchMute();
        PlayerPrefs.SetInt(Constants.VOLUME_IS_MUTE_NAME, isMuted ? 1 : 0);

        buttonMuteText.text = isMuted ? "Unmute" : "Mute";
    }
}
