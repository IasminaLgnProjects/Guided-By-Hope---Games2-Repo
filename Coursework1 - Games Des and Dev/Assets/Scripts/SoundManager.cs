using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    /*
    AudioSource audioSource;
    //[SerializeField] AudioClip win;
    //[SerializeField] AudioClip gameOver;


    [SerializeField] AudioClip playerDeath;
    //[SerializeField] AudioClip playerHit;

    //[SerializeField] AudioClip witchAttack;
    [SerializeField] AudioClip witchDeath;
    //[SerializeField] AudioClip witchThrow;

    [SerializeField] AudioClip potionBreak;


    //[SerializeField] AudioClip trollDeath;
    //[SerializeField] AudioClip trollAttack;

    //[SerializeField] AudioClip deerDeath;
    float defaultSoundLevel = 0.5f;
    */





    public Sound[] sounds;

    public static SoundManager instance;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.soundSource = gameObject.AddComponent<AudioSource>();
            s.soundSource.clip = s.clip;

            s.soundSource.volume = s.volume;
            s.soundSource.pitch = s.pitch;
            s.soundSource.loop = s.loop;
        }
    }

    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        PlayAudio("BackgroundMusic");
    }

    public void PlayAudio(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.soundSource.Play();
    }





    /*
    public void AudioWin()
    {
        //audioSource.PlayOneShot(win, defaultSoundLevel);
    }
    public void AudioPlayerDeath()
    {
        audioSource.PlayOneShot(playerDeath, defaultSoundLevel);
    }
    public void AudioWitchAttack()
    {
        //audioSource.PlayOneShot(witchAttack, defaultSoundLevel);
    }
    public void AudioWitchDeath()
    {
        audioSource.PlayOneShot(witchDeath, defaultSoundLevel);
    }
    public void AudioPotionBreak()
    {
        audioSource.PlayOneShot(potionBreak, defaultSoundLevel);
    }
    public void AudioTrollDeath()
    {
        //audioSource.PlayOneShot(trollDeath, defaultSoundLevel);
    }
    public void AudioTrollAttack()
    {
        //audioSource.PlayOneShot(trollAttack, defaultSoundLevel);
    }
    */
}
