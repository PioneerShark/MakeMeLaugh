using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] ostList, sfxList;
    [SerializeField] private AudioSource ostSource, sfxSource;

    public void PlayOST(string name)
    {
        AudioClip ost = Array.Find(ostList, x => x.name == name);
        if (ost != null)
        {
            ostSource.clip = ost;
            ostSource.loop = true;
            ostSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        AudioClip sfx = Array.Find(sfxList, x => x.name == name);
        if (sfx != null)
        {
            sfxSource.clip = sfx;
            sfxSource.Play();
        }
    }

    private void Awake() 
    {
        PlayOST("Give Them a Show");
    }
}
