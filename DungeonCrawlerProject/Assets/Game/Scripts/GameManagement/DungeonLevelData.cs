using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Core.GameManagement;
using Assets.Game.Gameplay.Characters;
using UnityEngine;

namespace Assets.Game.Dungeon
{
    public class DungeonLevelData : ILevelData
    {
        //TODO: create setters, validators etc.
        public DungeonCharacter[] DungeonCharacters { get; set; } = new DungeonCharacter[4];
        public CharacterData[] DungeonCharacterData { get; set; } = new CharacterData[4];
        public List<DungeonReward> Rewards { get; set; }
    }
}
