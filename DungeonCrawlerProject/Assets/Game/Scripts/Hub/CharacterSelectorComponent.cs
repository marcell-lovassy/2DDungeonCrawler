using Assets.Game.Gameplay.Characters;
using Assets.Game.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Hub
{
    public class CharacterSelectorComponent : ViewBaseComponent
    {
        [SerializeField]
        GameObject scrollViewContent;

        [SerializeField]
        Image[] slotIndicatorImages = new Image[4];

        [SerializeField]
        Sprite inactiveSlotSprite;
        [SerializeField]
        Sprite activeSlotSprite;

        public override bool IsBlocking { get; set; } = false;

        [field: SerializeField]
        public override List<ViewBaseComponent> childViews { get; set; }

        [SerializeField]
        SelectableCharacterSlotComponent slotPrefab;

        [SerializeField]
        Characters hiredCharacters;

        CharacterSelectionSlotComponent activeSlot;

        private List<SelectableCharacterSlotComponent> selectables = new List<SelectableCharacterSlotComponent>();

        public void SetSlot(CharacterSelectionSlotComponent slot)
        {
            ResetSlotIndicators();
            activeSlot = slot;
            slotIndicatorImages[activeSlot.slotIndex - 1].sprite = activeSlotSprite;
        }

        public override void Open()
        {
            ClearList();
            foreach (var item in hiredCharacters.GetHiredCharacters())
            {
                var slot = Instantiate(slotPrefab);
                slot.SetCharacterData(item);
                selectables.Add(slot);
                slot.transform.SetParent(scrollViewContent.transform, false);
            }
            base.Open();
        }

        public override void Close()
        {
            ClearList();
            ResetSlotIndicators();
            base.Close();
        }

        private void ClearList()
        {
            foreach (var item in selectables)
            {
                Destroy(item.gameObject);
            }
            selectables.Clear();
        }

        private void ResetSlotIndicators()
        {
            foreach (var image in slotIndicatorImages)
            {
                image.sprite = inactiveSlotSprite;
            }
        }

        public void SetActiveSlot()
        {

        }

    }
}

