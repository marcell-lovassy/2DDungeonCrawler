using System;
using System.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Core.UI;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

namespace Assets.Core.GameManagement
{
    public enum LoadingState
    {
        LoadingStarted,
        LoadingFinished,
        RequireUserInput,
        CanStartNextLevel,
    }


    public class LevelManager
    {
        public float LoadingProggress { get; private set; }
        public bool LevelIsLoading { get; private set; }
        public IObservable<LoadingState> LoadingStateChanged => loadingStateChanged;
        public int CurrentLevelIndex => SceneManager.GetActiveScene().buildIndex;
        public int ReachedLevelIndex
        {
            get
            {
                return PlayerPrefs.GetInt("ReachedLevel");
            }
            private set
            {
                PlayerPrefs.SetInt("ReachedLevel", value);
            }
        }

        public bool ButtonPressed = false;

        private Subject<bool> levelLoadingFinishedObservable = new Subject<bool>();
        private Subject<string> nextLevelStarted = new Subject<string>();
        private Subject<LoadingState> loadingStateChanged = new Subject<LoadingState>();
        private Animator gameFinishedAnimator;
        private LoadingAnimationFinisher loadingFinisher;
        private Stack<LoadingState> LoadingStateStack = new Stack<LoadingState>();
        private Slider loadingSlider;
        private TMP_Text loadingText;

        public void InitializeGameState()
        {
            if (ReachedLevelIndex == 0)
            {
                ReachedLevelIndex = 2;
            }
        }

        internal void SetGameFinishedAnimator(Animator animator)
        {
            gameFinishedAnimator = animator;
        }

        internal void SetAnimationFinisherComponent(LoadingAnimationFinisher animationFinisher)
        {
            loadingFinisher = animationFinisher;
        }

        internal void SetupLoadingSlider(Slider s, TMP_Text text)
        {
            loadingSlider = s;
            loadingText = text;
        }

        internal IEnumerator LoadGame()
        {
            return LoadLevel(ReachedLevelIndex);
        }


        public void OnDestroy()
        {
            levelLoadingFinishedObservable?.Dispose();
            nextLevelStarted?.Dispose();
        }

        public void HandleLoadingState(LoadingState state)
        {
            if (LoadingStateStack.Count == 0 || LoadingStateStack.Peek() != state)
            {
                if(LoadingStateStack.Count != 0) LoadingStateStack.Pop();
                LoadingStateStack.Push(state);
                loadingStateChanged.OnNext(state);
            }
        }

        public IEnumerator LoadLevelByIndex(int levelIndex, bool requiresUserInput = true)
        {
            return LoadLevel(levelIndex, null, requiresUserInput);
        }

        public IEnumerator LoadLevelByName(string levelName, bool requiresUserInput = true)
        {
            return LoadLevel(0, levelName, requiresUserInput);
        }

        private IEnumerator LoadLevel(int levelIndex, string levelName = null, bool requiresUserInput = true)
        {
            LevelIsLoading = true;
            bool canActivateNextScene = true;
            AsyncOperation loading = null;
            HandleLoadingState(LoadingState.LoadingStarted);
            if(levelName != null)
            {
                loading = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
            }
            else
            {
                loading = SceneManager.LoadSceneAsync(levelIndex, LoadSceneMode.Single);
            }
            loading.allowSceneActivation = false;
            UpdateLoadingSlider(0);
            yield return null;

            while (!loading.isDone)
            {
                SetLoadingSlider(loading.progress);
                if (loading.progress >= 0.9f && loadingSlider.value == 100)
                {

                    if (!loadingFinisher.Finished)
                    {
                        HandleLoadingState(LoadingState.LoadingFinished);
                    }
                    else
                    {
                        if (requiresUserInput && loadingFinisher.Finished)
                        {
                            canActivateNextScene = false;
                            HandleLoadingState(LoadingState.RequireUserInput);
                            if (ButtonPressed)
                            {
                                canActivateNextScene = true;
                                ButtonPressed = false;
                            }
                        }

                        if (canActivateNextScene)
                        {
                            HandleLoadingState(LoadingState.CanStartNextLevel);
                            loading.allowSceneActivation = true;
                        }
                    }
                }
                yield return new WaitForSeconds(0.1f);


            }
            LevelIsLoading = false;
        }

        internal IEnumerator LoadMainMenu()
        {
            return LoadLevel(1, null, true);
        }

        public IEnumerator LoadNextLevel()
        {
            return LoadLevel(CurrentLevelIndex + 1);
        }

        internal IEnumerator WinCurrentLevel()
        {
            if (SceneManager.sceneCountInBuildSettings > ReachedLevelIndex + 1)
            {
                ReachedLevelIndex++;
                return LoadNextLevel();
            }
            else
            {
                return StartGameFinishedSequence();
            }
        }

        private IEnumerator StartGameFinishedSequence()
        {
            ReachedLevelIndex = 0;
            yield return null;
            gameFinishedAnimator.SetTrigger("GameFinished");
        }

        private void UpdateLoadingSlider(float progress)
        {
            loadingSlider.value = progress >= 100 ? 100 : progress;
            loadingText.text = $"Loading... {loadingSlider.value}%";
        }

        /// <summary>
        /// Make loading visible in case of too fast loading, to make the animation smooth
        /// </summary>
        /// <param name="progress"></param>
        private void SetLoadingSlider(float progress)
        {
            if (loadingSlider.value < 30 || loadingSlider.value >= 90)
            {
                UpdateLoadingSlider(loadingSlider.value + UnityEngine.Random.Range(1, 3));
            }
            else
            {
                UpdateLoadingSlider(progress * 100);
            }
        }
    }
}