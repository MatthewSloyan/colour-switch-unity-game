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
        if (PlayerPrefs.GetString("Sound") == "True")
        {
            source.mute = false;
        }
        else
        {
            source.mute = true;
        }
    }

    public void playBackgroundMusic()
    {
        source.clip = backgroundMusic;
        source.Play();
    }

    public void playPlayerDiesClip()
    {
        source.PlayOneShot(playerDies);
    }

    public void playCollectStarClip()
    {
        source.PlayOneShot(collectStar);
    }

    public void playTapClip()
    {
        source.PlayOneShot(tapScreen);
    }
}
