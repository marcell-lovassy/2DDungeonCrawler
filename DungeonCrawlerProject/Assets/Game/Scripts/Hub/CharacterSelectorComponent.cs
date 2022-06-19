using Assets.Game.GameManagement;
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
        public override bool IsBlocking { get; set; } = false;


        [Header("UI Setup")]
        [SerializeField]
        GameObject scrollViewContent;
        [SerializeField]
        Image[] slotIndicatorImages = new Image[4];
        [SerializeField]
        Sprite inactiveSlotSprite;
        [SerializeField]
        Sprite activeSlotSprite;
        [SerializeField]
        [field: SerializeField]
        public override List<ViewBaseComponent> childViews { get; set; }


        [Header("Game Setup")]
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
            foreach (var availableCharacter in hiredCharacters.GetHiredCharacters())
            {
                if (DungeonDataProviderComponent.Instance.IsCharacterSelected(availableCharacter) && activeSlot.CharacterInSlot != availableCharacter)
                {
                    continue;
                }

                var slot = Instantiate(slotPrefab);
                slot.SetCharacterData(availableCharacter);
                selectables.Add(slot);
                slot.transform.SetParent(scrollViewContent.transform, false);
                slot.SetCharacterDataCallback += GetCharacterDataFromSlot;
                slot.RefreshSelection(activeSlot.GetSelected());
                
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
            foreach (var slot in selectables)
            {
                slot.SetCharacterDataCallback -= GetCharacterDataFromSlot;
                Destroy(slot.gameObject);
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

        public void GetCharacterDataFromSlot(CharacterData data)
        {
            activeSlot.SetCharacter(data);
            foreach (var slot in selectables)
            {
                slot.RefreshSelection(activeSlot.GetSelected());
            }
        }

        public void SetActiveSlot()
        {

        }

    }
}

