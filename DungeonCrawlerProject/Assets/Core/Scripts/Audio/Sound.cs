using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Core.Audio
{
    [Serializable]
    public class Sound
    {

        [SerializeField]
        private string name;

        private AudioSource source;

        [SerializeField]
        private AudioClip clip;

        [Range(0f, 1f)]
        [SerializeField]
        private float volume;

        [Range(-3f, 3f)]
        [SerializeField]
        private float pitch;

        [SerializeField]
        private bool loop;

        [SerializeField]
        private bool playOnAwake;


        public void Play()
        {
            source.Play();
        }

        public void SetupSound(AudioSource s)
        {
            source = s;
            source.clip = clip;
            source.volume = volume;
            source.pitch = pitch;
            source.loop = loop;
            source.playOnAwake = playOnAwake;
        }

        public string GetSoundName()
        {
            return name;
        }
    }
}
