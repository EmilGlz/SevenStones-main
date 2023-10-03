using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    #region Singleton
    private static AudioManager _instance;
    public static AudioManager Instance { get { return _instance; } }

    void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    #endregion

    const string savedMusicVolume = "mv";
    const string savedSoundVolume = "sv";

    public Sound[] sounds;

    public void Play( int soundIndex )
    {
        //Sound s = Array.Find(sounds, sound => sound.name == name); // find in sounds array a sound whose name is name
        Sound s = sounds[soundIndex];
        if (s == null)
        {
            return;
        }
        // If it is music
        if (soundIndex == 0 || soundIndex == 8)
        {
            if (PlayerPrefs.GetInt(savedMusicVolume) == 1)
            {
                s.source.Play();
            }
        }
        else // if it is sfx
        {
            if (PlayerPrefs.GetInt(savedSoundVolume) == 1)
            {
                s.source.Play();
            }
        }
    }

    public void Stop(int soundIndex)
    {
        //Sound s = Array.Find(sounds, sound => sound.name == name); // find in sounds array a sound whose name is name
        Sound s = sounds[soundIndex];
        if (s == null)
        {
            return;
        }
        s.source.Stop();
    }

    public void SetVolume(int soundIndex, float soundVolume)
    {
        //Sound s = Array.Find(sounds, sound => sound.name == name); // find in sounds array a sound whose name is name
        Sound s = sounds[soundIndex];
        if (s == null)
        {
            return;
        }
        s.source.volume = soundVolume;
    }
}
