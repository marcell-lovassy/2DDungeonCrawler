using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Gameplay.Characters
{
    public class SelectableCharacterSlotComponent : MonoBehaviour
    {
        [SerializeField]
        Image characterImage;

        [SerializeField]
        TMP_Text characterDisplayName;

        [SerializeField]
        TMP_Text charcterClass;

        [SerializeField]
        TMP_Text characterLevel;

        private CharacterData characterData;

        Button selectCharacterButton;

        private void Awake()
        {
            //selectCharacterButton.onClick.AddListener();
        }

        public void SetCharacterData(CharacterData data)
        {
            characterData = data;
            characterImage.sprite = characterData.characterIcon;
            characterDisplayName.text = characterData.characterName;
            charcterClass.text = characterData.characterClass.ToString();
            characterLevel.text = $"Level {characterData.level.ToString()}";
        }
    }
}
