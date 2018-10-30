using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class SoundManager {

    public AudioSource audioSource;
    public List<SoundStruct> sounds;

    public void SwitchSound(AudioClip clip)
    {
        SoundStruct str;
        str = sounds.Single(s => s.clip == clip) ;
        if (str.loop)
        {
            audioSource.clip = str.clip;
            audioSource.Play();

            
        }
        else
        {
            audioSource.PlayOneShot(str.clip);
        }
        audioSource.volume = str.volume;
        audioSource.loop = str.loop;

    }

}
