using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Core.Audio;
using System.Linq;

namespace Assets.Core.Audio
{
    public class AudioManagerComponent : MonoBehaviour
    {
        [SerializeField]
        private List<Sound> sounds;

        // Start is called before the first frame update
        void Awake()
        {
            sounds.ForEach(s => s.SetupSound(gameObject.AddComponent<AudioSource>()));
        }

        public Sound PlayMusic(string name)
        {
            var sound = GetSound(name);
            if (sound != null && !sound.IsPlaying())
            {
                sound.Play();
            }
            return sound;
        }

        public void PlayEffect(string name)
        {
            var sound = GetSound(name);
            sound?.Play();
        }

        public bool IsSoundPlaying(string name)
        {
            var s = sounds.FirstOrDefault(s => s.GetSoundName() == name);
            if (s == null)
            {
                Debug.LogWarning($"Can not find sound with the name {name}");
                return false;
            }
            return s.IsPlaying();
        }

        private Sound GetSound(string name)
        {
            var s = sounds.FirstOrDefault(s => s.GetSoundName() == name);
            if (s == null)
            {
                Debug.LogWarning($"Can not find sound with the name {name}");
                return null;
            }

            return s;
        }
    }
}

