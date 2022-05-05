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

        private Sound activeMusic = null;

        public ILevelData levelDataObject { get; set; }

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
            
            //no need to add DontDestroyOnLoad() here,
            //GameManager is on the ProjectContext (Zenject)

            //DontDestroyOnLoad(Instance);
        }

        private void Start()
        {
            InitGameState();
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
            PlayMusic("Theme");
        }

        #endregion

        void PlayMusic(string soundName)
        {
            activeMusic = AudioManager.PlayMusic(soundName);
        }

        private void OnLevelWasLoaded(int level)
        {
           InitGameState();
        }

        private void InitGameState()
        {
            var gamestate = FindObjectOfType<GameState>();
            if (gamestate != null)
            {
                StartGameStateMusic(gamestate);
               
                //else continue the same music
            }
        }

        void StartGameStateMusic(GameState gamestate)
        {
            if(activeMusic != null && activeMusic.GetSoundName() != gamestate.StateMusic)
            {
                activeMusic.Stop();
            }
            PlayMusic(gamestate.StateMusic);
        }
    }
}


