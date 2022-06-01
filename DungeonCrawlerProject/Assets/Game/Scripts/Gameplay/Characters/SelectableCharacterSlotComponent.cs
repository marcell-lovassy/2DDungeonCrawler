using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Gameplay.Characters
{
    public class SelectableCharacterSlotComponent : MonoBehaviour
    {
        public delegate void GetCharacterData(CharacterData data);
        public GetCharacterData SetCharacterDataCallback;
        
        [SerializeField]
        private Image characterImage;
        [SerializeField]
        private TMP_Text characterDisplayName;
        [SerializeField]
        private TMP_Text charcterClass;
        [SerializeField]
        private TMP_Text characterLevel;
        [SerializeField]
        Button selectCharacterButton;
        [SerializeField]
        private Image selectionIndicator;

        private CharacterData characterData;


        private void Awake()
        {
            selectionIndicator.gameObject.SetActive(false);
            selectCharacterButton.onClick.AddListener(() => SelectCharacter());
        }

        public void SetCharacterData(CharacterData data)
        {
            characterData = data;
            characterImage.sprite = characterData.characterIcon;
            characterDisplayName.text = characterData.characterName;
            charcterClass.text = characterData.characterClass.ToString();
            characterLevel.text = $"Level {characterData.level.ToString()}";
        }

        private void SelectCharacter()
        {
            SetCharacterDataCallback(characterData);
            selectionIndicator.gameObject.SetActive(true);
        }

        internal bool RefreshSelection(string name)
        {
            var selected = name == null ? false : characterData.characterName == name;
            selectionIndicator.gameObject.SetActive(selected);
            return selected;
        }
    }
}
