using UnityEngine;
using System.Collections.Generic;

public class SoundSFX : MonoBehaviour
{
    public static SoundSFX Instance;

    public Sound[] sounds;
    private Dictionary<string, AudioClip> soundDictionary;
    private AudioSource audioSource;

    void Awake()
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

        audioSource = GetComponent<AudioSource>();
        soundDictionary = new Dictionary<string, AudioClip>();

        foreach (Sound sound in sounds)
        {
            soundDictionary[sound.name] = sound.clip;
        }
    }

    public void PlaySound(string name)
    {
        if (soundDictionary.ContainsKey(name))
        {
            audioSource.PlayOneShot(soundDictionary[name]);
        }
        else
        {
            Debug.LogWarning("SoundSFX: Sound not found: " + name);
        }
    }
}

[System.Serializable]
public struct Sound
{
    public string name;
    public AudioClip clip;

}