using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InGameSoundManager : MonoBehaviour {

    public static InGameSoundManager instance;

    public List<SoundManager> soundManagers;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void SwitchSound(AudioSource source, AudioClip clip)
    {
        soundManagers.Single(s => s.audioSource == source).SwitchSound(clip);
    }

    public static void StopSound(AudioSource source)
    {
        source.Stop();
        source.clip = null;
        source.loop = false;
    }
}
