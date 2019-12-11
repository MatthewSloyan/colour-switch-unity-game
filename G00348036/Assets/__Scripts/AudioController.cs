using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    #region == Private Variables == 

    private AudioSource source;

    [SerializeField]
    private AudioClip backgroundMusic;

    [SerializeField]
    private AudioClip playerDies;

    [SerializeField]
    private AudioClip collectStar;

    [SerializeField]
    private AudioClip tapScreen;

    #endregion

    // Singleton design pattern to get instance of class
    public static AudioController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Use this for initialization
    void Start()
    {
        // Get AudioSource componant and start background music playing.
        source = GetComponent<AudioSource>();
        playBackgroundMusic();
    }

    void Update()
    {
        // Check if game audio is off using player prefs, if so mute audiosource.
        if (PlayerPrefs.GetString("Sound") == "True")
        {
            source.mute = false;
        }
        else
        {
            source.mute = true;
        }
    }

    // Play background music on startup
    public void playBackgroundMusic()
    {
        source.clip = backgroundMusic;
        source.Play();
    }

    // Plays death audio when game ends.
    public void playPlayerDiesClip()
    {
        // Plays audio once over background music.
        // https://docs.unity3d.com/ScriptReference/AudioSource.PlayOneShot.html
        source.PlayOneShot(playerDies);
    }

    // Plays sound when star score is collected.
    public void playCollectStarClip()
    {
        source.PlayOneShot(collectStar);
    }

    // Adds tap sound to all clicks
    public void playTapClip()
    {
        source.PlayOneShot(tapScreen);
    }
}
