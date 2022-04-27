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
        DungeonCharacter character;
    }
}
