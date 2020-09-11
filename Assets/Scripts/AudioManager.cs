using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public bool isMuted = false;
    public Sound[] sounds;
    // Volume in %
    public float generalVolume {get; set;}
    // Default played song is the MainTheme
    private string playedSong = Constants.MAIN_THEME;
    private float baseVolume;

    private void Awake()
    {
        // Singleton class - keep this audio manager (and songs) on other scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
            return;           
        }

        baseVolume = AudioListener.volume;

        SceneManager.sceneLoaded += OnSceneLoaded;


        // Getting volume setting from playerPref
        generalVolume = PlayerPrefs.GetFloat(Constants.GENERAL_VOLUME_NAME, Constants.GENERAL_VOLUME_VALUE);
        isMuted = PlayerPrefs.GetInt(Constants.VOLUME_IS_MUTE_NAME, 0) == 1 ? true : false;



        // Applying playerPref volume
        if (!isMuted)
            AudioListener.volume = baseVolume * (generalVolume / 100);
        else
            AudioListener.volume = 0;

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

     private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
     {
        switch (scene.name)
        {
            case "Credits":
                if (playedSong != Constants.CREDITS_THEME)
                {
                    Stop(playedSong);
                    playedSong = Constants.CREDITS_THEME;
                    Play(Constants.CREDITS_THEME);
                }
                break;
            default:
                if (playedSong != Constants.MAIN_THEME)
                {
                    Stop(playedSong);
                    playedSong = Constants.MAIN_THEME;
                    Play(Constants.MAIN_THEME);
                }
                break;
        }
     }

    private void Start()
    {
        // Only runs the first time the game is launched
        Play(playedSong);
    }

    public void ChangeGeneralVolume(float newVolume)
    {
        generalVolume = newVolume;
        // baseVolume is a reference of maximum volum at start, 
        // from which we diminish a percent
        if (!isMuted)
        {
            AudioListener.volume = baseVolume * (generalVolume / 100);
        }
    }

    public bool SwitchMute()
    {
        isMuted = !isMuted;

        if(isMuted)
            AudioListener.volume = 0;
        else
            AudioListener.volume = baseVolume * (generalVolume / 100);

        return isMuted;
    }

    public void Play(string name)
    {
        // Find the target song in the array of sounds and plays it
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            s.source.Play();
            return;
        }
        Debug.LogWarning("Sound: " + name + " not found");
        return;
    }

    public void Stop(string name)
    {
        // Find the target song in the array of sounds and stops it
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null && s.source.isPlaying)
        {
            s.source.Stop();
            return;
        }
        Debug.LogWarning("Sound: " + name + " not found or not playing");
        return;
    }
}
