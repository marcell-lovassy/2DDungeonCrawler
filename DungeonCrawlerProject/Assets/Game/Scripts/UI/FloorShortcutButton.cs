using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static TowerBaseComponent;

namespace Assets.Game.UI
{
    [RequireComponent(typeof(Button))]
    public class FloorShortcutButton : MonoBehaviour
    {
        string floorName;
        Button button;
        TMP_Text btnText;

        GoToFloorAction goToFloorAction;

        private void Awake()
        {
            button = GetComponent<Button>();
            btnText = GetComponentInChildren<TMP_Text>();
        }

        private void Start()
        {
            button.onClick.AddListener(FireAction);
        }

        public void SetupButton(string floorToGo, GoToFloorAction action)
        {
            floorName = floorToGo;
            btnText.text = floorName;
            goToFloorAction = action;
        }

        void FireAction()
        {
            goToFloorAction.Invoke(floorName);
        }
    }
}
