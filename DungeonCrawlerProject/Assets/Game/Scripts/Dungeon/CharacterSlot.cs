using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game.Dungeon
{
    public class CharacterSlot : MonoBehaviour
    {
        [SerializeField]
        CharacterSlot leftNeighbourSlot;

        [SerializeField]
        CharacterSlot rightNeighbourSlot;

        [SerializeField]
        DungeonCharacter _character;

        internal void SetCharacter(DungeonCharacter character)
        {
            if (character == null) return;
            _character = Instantiate(character);
            SetCharacterPosition();
        }

        private void SetCharacterPosition()
        {
            _character.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.transform.position.z);
        }
    }
}
