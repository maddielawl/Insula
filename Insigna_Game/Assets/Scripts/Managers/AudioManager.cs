using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    FMOD.Studio.Bus volume;

    public float masterVolume = 1f;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }

        volume = FMODUnity.RuntimeManager.GetBus("bus:/Master");
        volume.setVolume(masterVolume);
        
    }

    void Update()
    {
        volume.setVolume(masterVolume);
    }

  public void Play(string name)
    {
      Sound s =  Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public void PlayOneShot(string sound)
    {
        FMODUnity.RuntimeManager.PlayOneShot(sound);
    }

    public void changeVolume(float newMasterVolume)
    {
        masterVolume = newMasterVolume;
    }
}
