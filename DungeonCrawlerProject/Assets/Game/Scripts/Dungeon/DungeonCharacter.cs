using Assets.Game.Gameplay.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game.Dungeon
{
    public class DungeonCharacter : MonoBehaviour
    {
        [SerializeField]
        CharacterData characterData;

        [SerializeField]
        private string characterName;
        [SerializeField]
        private int characterLevel;
        [SerializeField]
        private CharacterClass characterClass;

        //Animator characterAnimator;

        private void Awake()
        {
            //characterAnimator = GetComponent<Animator>();
        }

        public void SetData(CharacterData data)
        {
            characterData = data;
            characterName = characterData.characterName;
            characterLevel = characterData.level;
            characterClass = characterData.characterClass;
        }
    }
}
