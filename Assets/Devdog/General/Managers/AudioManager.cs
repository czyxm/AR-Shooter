using System;
using System.Collections;
using System.Collections.Generic;
using Devdog.General.ThirdParty.UniLinq;
using System.Text;
using UnityEngine;
using UnityEngine.Audio;

namespace Devdog.General
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;

        //private static AudioSource[] _audioSources;
        //private static GameObject _audioSourceGameObject;
        public AudioClipInfo[] sounds;

        [Range(0f, 1f)]
        private float globalVolumn = 0.5f;

        public float GlobalVolume
        {
            get
            {
                return globalVolumn;
            }
            set
            {
                globalVolumn = value;
                foreach (AudioClipInfo s in sounds)
                {
                    s.source.volume = s.volume * value;
                }
            }
        }

        protected void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);

            foreach (AudioClipInfo s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.audioClip;
                s.source.volume = s.volume * globalVolumn;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }
            StartCoroutine(WaitFramesAndEnable(5));
            enabled = false; // Set to enabled at start, initialize, then enable (to avoid playing sound during initialization)
            //Play("Theme");
        }

        protected void Start()
        {
        }

        // Empty method to show enable / disable icons in Unity inspector.
        private void OnEnable(){ }

        private IEnumerator WaitFramesAndEnable(int frames)
        {
            for(int i = 0; i < frames; i++)
            {
                yield return null;
            }

            enabled = true;
        }

        //private void CreateAudioSourcePool()
        //{
        //    _audioSources = new AudioSource[GeneralSettingsManager.instance.settings.reserveAudioSources];

        //    _audioSourceGameObject = new GameObject("_AudioSources");
        //    _audioSourceGameObject.transform.SetParent(transform);
        //    _audioSourceGameObject.transform.localPosition = Vector3.zero;

        //    for (int i = 0; i < _audioSources.Length; i++)
        //    {
        //        _audioSources[i] = _audioSourceGameObject.AddComponent<AudioSource>();
        //        _audioSources[i].outputAudioMixerGroup = GeneralSettingsManager.instance.settings.audioMixerGroup;
        //    }
        //}

        //private static AudioSource GetNextAudioSource()
        //{
        //    foreach (var audioSource in _audioSources)
        //    {
        //        if (audioSource.isPlaying == false)
        //            return audioSource;
        //    }

        //    DevdogLogger.LogWarning("All sources taken, can't play audio clip...");
        //    return null;
        //}
        public AudioClipInfo FindClip(string name)
        {
            AudioClipInfo s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.LogWarning("Audio clip " + name + " not found.");
                return null;
            }
            return s;
        }


        public void Stop(string name)
        {
            FindClip(name).source.Stop();
        }

        public void Play(string name)
        {
            if (!FindClip(name).source.isPlaying)
            {
                FindClip(name).source.Play();
            }
        }


        /// <summary>
        /// Plays an audio clip, only use this for the UI, it is not pooled so performance isn't superb.
        /// </summary>
        public static void AudioPlayOneShot(AudioClipInfo clip)
        {
            if (clip == null || clip.audioClip == null)
            {
                return;
            }

            if (Instance == null)
            {
                DevdogLogger.LogWarning("AudioManager not found, yet trying to play an audio clip....");
            }
        }
    }
}