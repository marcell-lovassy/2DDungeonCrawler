using Assets.Core.GameManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.UI
{
    /// <summary>
    /// Temporary component for starting dungeons easily
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class DungeonStarterComponent : MonoBehaviour
    {
        [SerializeField]
        string dungeonName;

        Button dungeonStarterButton;

        private void Start()
        {
            dungeonStarterButton = GetComponent<Button>();

            dungeonStarterButton.onClick.AddListener(() => TryStartDungeon());
        }

        private void TryStartDungeon()
        {
            GameManagerComponent.Instance.LoadLevel(dungeonName);
        }

        private void ShowDungeonInfo()
        {
            
        }

        public void SetButton(bool active)
        {
            dungeonStarterButton.interactable = active;
        }
    }
}
