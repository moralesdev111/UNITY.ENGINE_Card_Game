using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSources, sfxSources;


    private void Start()
    {
        PlayMusic("background");
    }

    
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            musicSources.clip = s.clip;
            musicSources.Play();
        }
    }


    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            sfxSources.PlayOneShot(s.clip);
        }
    }
}
