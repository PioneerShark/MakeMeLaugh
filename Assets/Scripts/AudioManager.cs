using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Hmmm idk about this practice but okay
    public static AudioManager Instance;

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
        else
        {
            Debug.LogError("OST not found!");
        }
    }

    public void PlaySFX(string name)
    {
        AudioClip sfx = Array.Find(sfxList, x => x.name == name);
        if (sfx != null)
        {
            sfxSource.PlayOneShot(sfx);
        }
        else
        {
            Debug.LogError("SFX not found!");
        }
    }

    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //PlayOST("Give Them a Show");
        PlayOST("Clown's Respite");
        PlaySFX("Cheat-o");
    }
}
