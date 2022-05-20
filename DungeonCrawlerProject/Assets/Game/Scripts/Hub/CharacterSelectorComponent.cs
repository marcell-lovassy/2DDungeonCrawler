using Assets.Game.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Game.Hub
{
    public class CharacterSelectorComponent : ViewBaseComponent
    {
        [SerializeField]
        TMP_Text slotText;

        public override bool IsBlocking { get; set; } = false;

        [field: SerializeField]
        public override List<ViewBaseComponent> childViews { get; set; }

        CharacterSelectionSlotComponent activeSlot;


        public void SetSlot(CharacterSelectionSlotComponent slot)
        {
            activeSlot = slot;
            slotText.text = $"Adventurer {activeSlot.slotIndex}";
        }
        
    }
}

