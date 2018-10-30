﻿using UnityEngine;

[System.Serializable]
public struct SoundStruct
{
    public AudioClip clip;
    [Range(0,1)]
    public float volume;
    public bool loop;
}