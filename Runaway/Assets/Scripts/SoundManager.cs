using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;
    public AudioSource soundFX, gameAudio;

    public AudioClip[] gamesMusic;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (gameAudio.playOnAwake)
        {
            gameAudio.clip = gamesMusic[Random.Range(0, gamesMusic.Length)];
            gameAudio.Play();
        }
    }

    void Update()
    {
        if (!gameAudio.isPlaying)
        {
            gameAudio.clip = gamesMusic[Random.Range(0, gamesMusic.Length)];
            gameAudio.Play(); 
        }
    }


    public void PlaySound(AudioClip clip)
    {
        soundFX.clip = clip;
       soundFX.volume = Random.Range(.30f, .40f);
        soundFX.pitch = Random.Range(.8f, 1);
        soundFX.Play();
    }

  
}
