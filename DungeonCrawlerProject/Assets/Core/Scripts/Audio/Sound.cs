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
        [Header("Audio Setup")]
        [SerializeField]
        private string name;
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
        [SerializeField]
        [Range(0.1f, 1f)]
        float fadeTimeModifier = 0.5f;


        private AudioSource source;

        public bool IsStarted { get; private set; }

        public Coroutine RunningCoroutine { get; set; }

        public void Play()
        {
            source.Play();
        }

        public System.Collections.IEnumerator StartMusic()
        {
            if (!IsPlaying())
            {
                source.volume = 0;
                source.Play();
            }

            var t = 0.0f;
            while (t <= 1.0f)
            {
                t += fadeTimeModifier * Time.deltaTime;
                source.volume = Mathf.Lerp(source.volume, volume, t);
                yield return null;
            }
        }

        public System.Collections.IEnumerator StopMusic()
        {
            var t = 0.0f;
            while (t <= 1.0f)
            {
                t += fadeTimeModifier * Time.deltaTime;
                source.volume = Mathf.LerpUnclamped(source.volume, 0, t);
                yield return null;
            }
            source.Stop();
        }

        public System.Collections.IEnumerator PauseMusic()
        {
            var t = 0.0f;
            while (t <= 1.0f)
            {
                t += fadeTimeModifier * Time.deltaTime;
                source.volume = Mathf.LerpUnclamped(source.volume, 0, t);

                yield return null;
            }
            source.Pause();
        }

        public void Stop()
        {
            source.Stop();
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

        public void PlayEffect()
        {
            source.PlayOneShot(clip);
        }

        public string GetSoundName()
        {
            return name;
        }

        public void Pause()
        {
            source.Pause();
        }

        public bool IsPlaying()
        {
            return source.isPlaying;
        }

        public void SetCoroutine(Coroutine c)
        {
            RunningCoroutine = c;
        }
    }
}
