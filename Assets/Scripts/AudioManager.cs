using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;



    public void SoundFx(int name)
    {
        audioSource.clip = audioClips[name];
        audioSource.Play();
    }

    public void PlayOneFx(int name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }

    public void StopSound()
    {
        audioSource.Stop();
    }

}
