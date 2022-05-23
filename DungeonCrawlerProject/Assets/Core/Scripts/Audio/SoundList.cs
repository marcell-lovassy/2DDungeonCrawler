using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Core.Audio
{
    [Serializable]
    public class SoundList
    {
        [Header("Main Settings")]
        [SerializeField]
        public string ListName;
        [SerializeField]
        public Sound mainMusic;

        [Header("Sounds")]
        [SerializeField]
        float playIntervalMin;
        [SerializeField]
        float playIntervalMax;
        [SerializeField]
        public List<Sound> Sounds;

        bool playing;

        public System.Collections.IEnumerator Play()
        {
            playing = true;
            mainMusic.Play();

            if (Sounds.Count != 0)
            {
                while (playing)
                {
                    var wait = UnityEngine.Random.Range(playIntervalMin, playIntervalMax);
                    var index = UnityEngine.Random.Range(0, Sounds.Count);
                    Sounds.ElementAt(index).PlayEffect();
                    yield return new WaitForSeconds(wait);
                }
            }
            
            yield return null;

        }

        public void Pause()
        {
            playing = false;
            mainMusic.Pause();
        }

        public void Stop()
        {
            playing = false;
            mainMusic.Stop();
        }
    }
}
