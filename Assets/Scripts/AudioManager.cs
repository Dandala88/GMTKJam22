using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public int index;
    public AudioClip[] songs;

    private void Awake()
    {
        index = 0;
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = songs[index++];

            if (index == songs.Length)
                index = 0;

            audioSource.Play();
        }
    }
}
