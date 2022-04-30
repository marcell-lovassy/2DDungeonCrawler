using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Assets.Core.GameManagement;

namespace Assets.Game.UI
{
    public class MainMenuComponent : MonoBehaviour
    {

        [SerializeField]
        private Button startButton;

        [SerializeField]
        private Button settingsButton;

        [SerializeField]
        private Button quitButton;


        private void Awake()
        {
            startButton.onClick.AddListener(StartOrContinueGame);
        }

        private void StartOrContinueGame()
        {
            GameManagerComponent.Instance.LoadNextLevel();
        }
    }

}

