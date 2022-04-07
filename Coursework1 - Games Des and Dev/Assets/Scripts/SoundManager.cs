using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;

    public static SoundManager instance;

    void Start()
    {
        PlayAudio("BackgroundMusic");
    }

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

    public void PlayAudio(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("The sound: " + name + "cannot be found!");
            return;
        }

        s.soundSource.Play();
    }
}
