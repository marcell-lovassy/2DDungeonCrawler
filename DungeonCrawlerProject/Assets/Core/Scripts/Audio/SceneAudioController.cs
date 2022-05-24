using Assets.Core.Audio;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Assets.Core.Audio
{
    /// <summary>
    /// Audio Contrtoller for scenes
    /// TODO: rework AudioManagerComponent -> create a global AudioController that has some sounds and always available, 
    /// but create audio controller for every scene
    /// </summary>
    public class SceneAudioController : MonoBehaviour
    {
        [Header("Base Music")]
        [SerializeField]
        List<Sound> sounds;

        [Header("Special Sounds")]
        [SerializeField]
        List<SoundList> soundLists;

        public static SceneAudioController Instance;
        private List<Sound> allSoundsInScene;

        Coroutine currentCoroutine;

        private void Awake()
        {
            // new SceneAudioContoller on every scene
            Instance = this;
            SetupSounds();

            PlayTheme();
        }

        private void SetupSounds()
        {
            sounds.ForEach(s => s.SetupSound(gameObject.AddComponent<AudioSource>()));

            foreach (var list in soundLists)
            {
                list.mainMusic.SetupSound(gameObject.AddComponent<AudioSource>());
                foreach (var sound in list.Sounds)
                {
                    sound.SetupSound(gameObject.AddComponent<AudioSource>());
                }
            }

            allSoundsInScene = GetAllSounds();
        }

        private List<Sound> GetAllSounds()
        {
            List<Sound> all = new List<Sound>();
            all.AddRange(sounds);

            soundLists.ForEach(s => all.Add(s.mainMusic));
            soundLists.ForEach(s => all.AddRange(s.Sounds));

            return all;
        }

        private void PlayTheme()
        {
            foreach (var music in sounds)
            {
                StopSoundCoroutine(music);
                music.SetCoroutine(StartCoroutine(music.StartMusic()));
            }
        }

        public void StartMusic(Sound s)
        {
            StopSoundCoroutine(s);
            s.SetCoroutine(StartCoroutine(s.StartMusic()));
        }

        private void PauseTheme()
        {
            foreach (var music in sounds)
            {
                StopSoundCoroutine(music);
                music.SetCoroutine(StartCoroutine(music.PauseMusic()));
            }
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
            PlayEffect(sound);
        }

        public void PlayEffect(Sound sound)
        {
            if(sound != null)
            {
                sound?.PlayEffect();
            }
        }

        public void StopAllMusic()
        {
            foreach (var sound in sounds)
            {
                StopSoundCoroutine(sound);
                sound.SetCoroutine(StartCoroutine(sound.StopMusic()));
            }
        }

        public void StopMusic(string name)
        {
            var sound = GetSound(name);
            if (sound != null && sound.IsPlaying())
            {
                StopSoundCoroutine(sound);
                sound.SetCoroutine(StartCoroutine(sound.StopMusic()));
            }
        }

        public void PauseMusic(string name)
        {
            var sound = GetSound(name);
            if (sound != null && sound.IsPlaying())
            {
                StopSoundCoroutine(sound);
                sound.SetCoroutine(StartCoroutine(sound.PauseMusic()));
            }
        }
        public bool IsSoundPlaying(string name)
        {
            var s = allSoundsInScene.FirstOrDefault(s => s.GetSoundName() == name);
            if (s == null)
            {
                Debug.LogWarning($"Can not find sound with the name {name}");
                return false;
            }
            return s.IsPlaying();
        }

        private Sound GetSound(string name)
        {
            var s = allSoundsInScene.FirstOrDefault(s => s.GetSoundName() == name);
            if (s == null)
            {
                Debug.LogWarning($"Can not find sound with the name {name}");
                return null;
            }

            return s;
        }

        private void AddSound(Sound s)
        {
            if (!sounds.Contains(s))
            {
                s.SetupSound(gameObject.AddComponent<AudioSource>());
                sounds.Add(s);
            }
        }

        private void RemoveSound(Sound s)
        {
            if (sounds.Contains(s))
            {
                sounds.Remove(s);
            }
        }

        public void PlayList(string listName)
        {
            PauseTheme();
            var list = soundLists.FirstOrDefault(sl => sl.ListName == listName);
            if(list != null)
            {
                StartCoroutine(PlayList(list));
            }
        }

        private IEnumerator PlayList(SoundList list)
        {
            list.playing = true;
            StartMusic(list.mainMusic);

            if (list.Sounds.Count != 0)
            {
                while (list.playing)
                {
                    var wait = UnityEngine.Random.Range(list.playIntervalMin, list.playIntervalMax);
                    var index = UnityEngine.Random.Range(0, list.Sounds.Count);
                    PlayEffect(list.Sounds.ElementAt(index));

                    yield return new WaitForSeconds(wait);
                }
            }

            yield return null;
        }

        public void StopList(string listName)
        {
            var list = soundLists.FirstOrDefault(sl => sl.ListName == listName);
            if (list != null)
            {
                list.Stop();
                StopMusic(list.mainMusic.GetSoundName());
            }

            PlayTheme();
        }

        public void PauseList(string listName)
        {
            var list = soundLists.FirstOrDefault(sl => sl.ListName == listName);
            if (list != null)
            {
                list.Pause();
                PauseMusic(list.mainMusic.GetSoundName());
            }
            PlayTheme();
        }

        private void StopSoundCoroutine(Sound s)
        {
            if(s.RunningCoroutine != null)
            {
                StopCoroutine(s.RunningCoroutine);
            }
        }
    }
}
