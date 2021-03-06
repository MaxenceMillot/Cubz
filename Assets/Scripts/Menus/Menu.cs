﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text buttonMuteText;

    private void Start()
    {
        bool isMuted = AudioManager.instance.isMuted;
        buttonMuteText.text = isMuted ? "Unmute" : "Mute";
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LevelSelection()
    {
        SceneManager.LoadScene(10);
    }

    public void Settings()
    {
        SceneManager.LoadScene(11);
    }

    public void Credits()
    {
        SceneManager.LoadScene(8);
    }

    public void SwitchMute()
    {
        bool isMuted = AudioManager.instance.SwitchMute();
        PlayerPrefs.SetInt(Constants.VOLUME_IS_MUTE_NAME, isMuted?1:0);

        buttonMuteText.text = isMuted ? "Unmute" : "Mute";
    }
}
