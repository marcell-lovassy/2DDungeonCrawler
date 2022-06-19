using Assets.Game.Dungeon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Gameplay.Characters
{
    public enum CharacterClass
    {
        Warrior,
        Archer,
        Assassin
    }

    [CreateAssetMenu(menuName = "ScriptableObjects/CharacterData")]
    public class CharacterData : ScriptableObject
    {
        public string characterName;
        int characterId;
        public CharacterClass characterClass;
        public int level;
        CharacterStats stats;
        public Sprite characterIcon;
        public DungeonCharacter dungeonCharacterPrefab;
    }
}

