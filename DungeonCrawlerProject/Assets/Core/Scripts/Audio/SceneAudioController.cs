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

        public void StartMusic(Sound sound)
        {
            StopSoundCoroutine(sound);
            sound.SetCoroutine(StartCoroutine(sound.StartMusic()));
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

        private void AddSound(Sound sound)
        {
            if (!sounds.Contains(sound))
            {
                sound.SetupSound(gameObject.AddComponent<AudioSource>());
                sounds.Add(sound);
            }
        }

        private void RemoveSound(Sound sound)
        {
            if (sounds.Contains(sound))
            {
                sounds.Remove(sound);
            }
        }

        public void PlaySoundList(string listName)
        {
            PauseTheme();
            var list = soundLists.FirstOrDefault(sl => sl.ListName == listName);
            if(list != null)
            {
                StartCoroutine(PlaySoundList(list));
            }
        }

        private IEnumerator PlaySoundList(SoundList soundList)
        {
            soundList.playing = true;
            StartMusic(soundList.mainMusic);

            if (soundList.Sounds.Count != 0)
            {
                while (soundList.playing)
                {
                    var wait = UnityEngine.Random.Range(soundList.playIntervalMin, soundList.playIntervalMax);
                    var index = UnityEngine.Random.Range(0, soundList.Sounds.Count);
                    PlayEffect(soundList.Sounds.ElementAt(index));

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
