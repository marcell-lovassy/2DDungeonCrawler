using UnityEngine;
using TMPro;
using UniRx;
using System;
using Zenject;
using Assets.Core.UI;
using UnityEngine.UI;

namespace Assets.Core.GameManagement
{
    public class LevelManagerComponent : MonoBehaviour
    {
        [Header("Level Loading UI Elements")]
        [SerializeField]
        TMP_Text pressButtonText;
        [SerializeField]
        Slider loadingSlider;
        [SerializeField]
        TMP_Text loadingText;

        [SerializeField]
        Animator loadingAnimator;
        [SerializeField]
        Animator gameFinishedAnimator;

        [SerializeField]
        LoadingAnimationFinisher loadingAnimationFinisher;

        [Inject]
        private LevelManager levelManager;

        private LoadingState loadingState;

        private void Awake()
        {
            pressButtonText.gameObject.SetActive(false);
            //levelManager.SetGameFinishedAnimator(gameFinishedAnimator);
            levelManager.LoadingStateChanged.Subscribe(OnLoadingStateChnaged).AddTo(this);
            levelManager.SetAnimationFinisherComponent(loadingAnimationFinisher);
            levelManager.SetupLoadingSlider(loadingSlider, loadingText);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && loadingState == LoadingState.RequireUserInput)
            {
                levelManager.ButtonPressed = true;
            }
        }

        internal void LoadMenu()
        {
            if (levelManager.LevelIsLoading) return;
            StartCoroutine(levelManager.LoadMainMenu());
        }

        internal void Init()
        {
            levelManager.InitializeGameState();
        }

        internal void WinLevel()
        {
            StartCoroutine(levelManager.WinCurrentLevel());
        }

        internal void LoadGame()
        {
            if (levelManager.LevelIsLoading) return;
            StartCoroutine(levelManager.LoadGame());
        }

        public void LoadNextLevel()
        {
            if (levelManager.LevelIsLoading) return;
            StartCoroutine(levelManager.LoadNextLevel());
        }

        private void OnLoadingStateChnaged(LoadingState state)
        {
            loadingAnimator.SetTrigger(state.ToString());
            loadingState = state;
        }

        public void LoadlevelByName(string dungeonName)
        {
            if (levelManager.LevelIsLoading) return;
            StartCoroutine(levelManager.LoadLevelByName(dungeonName));
        }
    }
}

