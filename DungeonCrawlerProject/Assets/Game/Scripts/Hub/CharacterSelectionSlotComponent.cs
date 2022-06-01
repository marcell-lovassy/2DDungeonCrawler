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

        private CharacterData characterInSlot;

        private void Awake()
        {
            characterIcon.gameObject.SetActive(false);
            plusIcon.gameObject.SetActive(true);
        }

        internal void SetCharacter(CharacterData data)
        {
            characterInSlot = data;
            characterIcon.sprite = data.characterIcon;
            characterIcon.gameObject.SetActive(true);
            plusIcon.gameObject.SetActive(false);
        }

        public string GetSelected()
        {
            return characterInSlot == null ? null : characterInSlot.characterName;
        }
    }
}

