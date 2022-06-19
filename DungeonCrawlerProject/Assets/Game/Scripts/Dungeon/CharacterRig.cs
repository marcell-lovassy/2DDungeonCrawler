using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Core.GameManagement;
using Assets.Game.Gameplay.Characters;

namespace Assets.Game.Dungeon
{
    public class CharacterRig : MonoBehaviour
    {
        [Header("Slot Setup")]
        [SerializeField]
        CharacterSlot[] characterSlots = new CharacterSlot[4];
        [SerializeField]
        float maxSlotDistance;
        [SerializeField]
        float minSlotDistance;

        DungeonCharacter[] characters;
        CharacterData[] charactersData;

        private void Awake()
        {
            characters = (GameManagerComponent.Instance.levelDataObject as DungeonLevelData).DungeonCharacters;
            charactersData = (GameManagerComponent.Instance.levelDataObject as DungeonLevelData).DungeonCharacterData;
        }

        private void Start()
        {
            SetupCharacters();
        }

        private void SetupCharacters()
        {
            int i = 0;
            foreach (var character in charactersData)
            {
                if (character == null)
                {
                    Debug.LogWarning("Can not be null");
                    return;
                }
                characterSlots[i].SetCharacter(character);
                characterSlots[i].SetDistances(minSlotDistance, maxSlotDistance);
                i++;
            }

            //foreach (var character in characters)
            //{
            //    characterSlots[i].SetCharacter(character);
            //    characterSlots[i].SetDistances(minSlotDistance, maxSlotDistance);
            //    i++;
            //}
        }

        public CharacterSlot GetLeadingSlot()
        {
            return characterSlots[0];
        }
    }
}
