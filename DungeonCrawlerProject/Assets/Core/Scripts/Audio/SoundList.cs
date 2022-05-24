using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Core.Audio
{
    /// <summary>
    /// Soundlist is a class that can be used to create sound groups, to play them together 
    /// </summary>
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
        public float playIntervalMin;
        [SerializeField]
        public float playIntervalMax;
        [SerializeField]
        public List<Sound> Sounds;

        public bool playing { get; set; }

        public void Pause()
        {
            playing = false;
        }

        public void Stop()
        {
            playing = false;
        }
    }
}
