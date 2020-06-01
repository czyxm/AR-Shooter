using System;
using UnityEngine;

namespace Devdog.General
{
    [Serializable]
    public class AudioClipInfo
    {
        public string name;
        public AudioClip audioClip;

        [HideInInspector]
        public AudioSource source;

        [Range(0f, 1f)]
        public float volume = 1f;
        [Range(.1f, 3f)]
        public float pitch = 1f;
        public bool loop = false;
    }
}
