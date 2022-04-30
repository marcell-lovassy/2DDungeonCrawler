using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Core.UI
{
    enum MenuStage
    {
        Main,
        Settings,
        Extras
    }

    public class MainMenuComponent : MonoBehaviour
    {
        [SerializeField]
        Button playButton;
        [SerializeField]
        Button settingsButton;
        [SerializeField]
        Button backButton;
        [SerializeField]
        Button quitButton;
        [SerializeField]
        GameObject menu;
        [SerializeField]
        GameObject settings;

        private Stack<MenuStage> menuStageStack;

        private bool allowInput = false;


        void Start()
        {
            allowInput = true;
            SetUpButtonFunctions();
        }


        private void PlayOrContinue()
        {
            if (!allowInput) return;
            Debug.Log("You have clicked the Play button!");
            //allowInput = false;
            GameManagement.GameManagerComponent.Instance.LoadGame();
        }

        private void GoToSettings()
        {
            if (!allowInput) return;

            Debug.Log("You have clicked the Settings button!");
            menu.SetActive(false);
            settings.SetActive(true);
        }

        private void QuitGame()
        {
            if (!allowInput) return;

            Debug.Log("You have clicked the Quit button!");
        }
        private void BackToMenu()
        {
            if (!allowInput) return;

            settings.SetActive(false);
            menu.SetActive(true);
        }

        private void SetUpButtonFunctions()
        {
            if (playButton == null) Debug.LogWarning("playButton button is not wired");
            else playButton.onClick.AddListener(PlayOrContinue);

            if (settingsButton == null) Debug.LogWarning("settingsButton button is not wired");
            else settingsButton.onClick.AddListener(GoToSettings);

            if (backButton == null) Debug.LogWarning("backButton button is not wired");
            else settingsButton.onClick.AddListener(BackToMenu);

            if (quitButton == null) Debug.LogWarning("quitButton button is not wired");
            else settingsButton.onClick.AddListener(QuitGame);
        }
    }

}

