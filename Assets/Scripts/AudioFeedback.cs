using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFeedback : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource targetAudioSource;
    [Range(0, 1)]
    public float volume = 1;

    public void PlayClip()
    {
        targetAudioSource.volume = volume;
        targetAudioSource.PlayOneShot(clip);
    }

    public void PlaySpecificClip(AudioClip clip = null)
    {
        if (clip == null) clip = this.clip;
        if (clip == null) return;

        targetAudioSource.volume = volume;
        targetAudioSource.PlayOneShot(clip);
    }
}
