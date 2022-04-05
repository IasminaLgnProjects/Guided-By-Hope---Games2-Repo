using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
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

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
}
