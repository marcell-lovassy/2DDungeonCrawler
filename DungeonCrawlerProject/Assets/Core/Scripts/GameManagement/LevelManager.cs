using System;
using System.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Core.UI;
using System.Collections.Generic;

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

        private Subject<bool> levelLoadingFinishedObservable = new Subject<bool>();
        private Subject<string> nextLevelStarted = new Subject<string>();
        private Subject<LoadingState> loadingStateChanged = new Subject<LoadingState>();
        private Animator gameFinishedAnimator;
        private LoadingAnimationFinisher loadingFinisher;
        private Stack<LoadingState> LoadingStateStack = new Stack<LoadingState>();

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

        public IEnumerator LoadLevel(int levelIndex, bool requiresUserInput = true)
        {
            LevelIsLoading = true;
            bool canActivateNextScene = true;

            HandleLoadingState(LoadingState.LoadingStarted);
            yield return null;

            AsyncOperation loading = SceneManager.LoadSceneAsync(levelIndex, LoadSceneMode.Single);
            loading.allowSceneActivation = false;
            Debug.Log($"Progress {loading.progress}");
            while (!loading.isDone)
            {
                LoadingProggress = loading.progress;
                if (loading.progress >= 0.9f)
                {
                    if (!loadingFinisher.Finished)
                    {
                        HandleLoadingState(LoadingState.LoadingFinished);
                    }
                    else
                    {
                        if (requiresUserInput)
                        {
                            canActivateNextScene = false;
                            HandleLoadingState(LoadingState.RequireUserInput);
                            if (Input.GetKeyDown(KeyCode.Space))
                            {
                                canActivateNextScene = true;
                            }
                        }

                        if (canActivateNextScene)
                        {
                            HandleLoadingState(LoadingState.CanStartNextLevel);
                            loading.allowSceneActivation = true;
                        }
                    }
                }
                else
                {
                    Debug.Log($"Progress {loading.progress * 100}%");
                }
                yield return null;
            }
            LevelIsLoading = false;
        }

        internal IEnumerator LoadMainMenu()
        {
            return LoadLevel(1, false);
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
    }
}