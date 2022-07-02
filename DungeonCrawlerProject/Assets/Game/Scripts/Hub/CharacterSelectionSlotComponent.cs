using Assets.Game.GameManagement;
using Assets.Game.Gameplay.Characters;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Hub
{
    public class CharacterSelectionSlotComponent : MonoBehaviour
    {
        public CharacterData CharacterInSlot { get; private set; }
        public IObservable<Unit> SelectedCharacterCahnged => selectedCharacterCahnged;

        public int slotIndex;

        [SerializeField]
        private Image characterIcon;
        [SerializeField]
        private Image plusIcon;

        private Subject<Unit> selectedCharacterCahnged = new Subject<Unit>();

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
            selectedCharacterCahnged.OnNext(Unit.Default);
        }

        public string GetSelected()
        {
            return CharacterInSlot == null ? null : CharacterInSlot.characterName;
        }

        public bool IsSet()
        {
            return CharacterInSlot != null;
        }
    }
}

