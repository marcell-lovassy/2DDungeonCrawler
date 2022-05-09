using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Core.GameManagement;

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

        DungeonLevelData dungeonData;

        private void Awake()
        {
            dungeonData = (DungeonLevelData)GameManagerComponent.Instance.levelDataObject;
        }

        private void Start()
        {
            SetupCharacters();
        }


        private void SetupCharacters()
        {
            int i = 0;
            foreach (var character in dungeonData.DungeonCharacters)
            {
                characterSlots[i].SetCharacter(character);
                characterSlots[i].SetDistances(minSlotDistance, maxSlotDistance);
                i++;
            }
        }

        public CharacterSlot GetLeadingSlot()
        {
            return characterSlots[0];
        }
    }
}
