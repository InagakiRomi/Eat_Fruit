using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip change;
    AudioSource audiosource;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void PLAYchange()
    {
        audiosource.clip = change;
        audiosource.Play();
    }
}
