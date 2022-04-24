using Assets.Core.Audio;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Core.GameManagement
{
    public class GameManagerComponent : MonoBehaviour
    {
        [Header("Manager Objects")]
        [SerializeField]
        private LevelManagerComponent LevelManager;
        [SerializeField]
        private AudioManagerComponent AudioManager;

        public static GameManagerComponent Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(this);
            }

            LevelManager.Init();
            DontDestroyOnLoad(Instance);
        }

        #region LevelManagerCalls

        public void LoadNextLevel()
        {
            LevelManager.LoadNextLevel();
        }

        internal void LoadGame()
        {
            LevelManager.LoadGame();
        }

        public void WinLevel()
        {
            LevelManager.WinLevel();
        }

        internal void LoadMenu()
        {
            LevelManager.LoadMenu();
            PlaySound("Theme");
        }

        #endregion

        void PlaySound(string soundName)
        {
            AudioManager.Play(soundName);
        }
    }
}


