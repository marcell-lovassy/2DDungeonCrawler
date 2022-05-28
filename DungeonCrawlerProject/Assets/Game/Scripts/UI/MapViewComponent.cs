using Assets.Core.GameManagement;
using Assets.Game.Hub;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Game.UI
{
    public class MapViewComponent : ViewBaseComponent
    {
        [SerializeField]
        CharacterSelectorComponent characterSelector;

        public override bool IsBlocking { get; set; } = true;

        [field: SerializeField]
        public override List<ViewBaseComponent> childViews { get; set; }

        protected override void Awake()
        {
            base.Awake();
        }

        public void OpenCharacterPanel(CharacterSelectionSlotComponent slot)
        {
            characterSelector.SetSlot(slot);
            characterSelector.Open();
        }

        public void CloseCharacterPanel() 
        {
            characterSelector.Close(); 
        }

        
    }
}

