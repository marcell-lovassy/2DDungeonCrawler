using Assets.Game.GameManagement;
using Assets.Game.Gameplay.Characters;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Hub
{
    public class CharacterSelectionSlotComponent : MonoBehaviour
    {
        public int slotIndex;

        [SerializeField]
        private Image characterIcon;

        [SerializeField]
        private Image plusIcon;

        public CharacterData CharacterInSlot { get; private set; }

        private void Awake()
        {
            characterIcon.gameObject.SetActive(false);
            plusIcon.gameObject.SetActive(true);
        }

        internal void SetCharacter(CharacterData data)
        {
            CharacterInSlot = data;
            characterIcon.sprite = data.characterIcon;
            characterIcon.gameObject.SetActive(true);
            plusIcon.gameObject.SetActive(false);

            DungeonDataProviderComponent.Instance.SetCharacterData(slotIndex - 1, CharacterInSlot);
        }

        public string GetSelected()
        {
            return CharacterInSlot == null ? null : CharacterInSlot.characterName;
        }
    }
}

