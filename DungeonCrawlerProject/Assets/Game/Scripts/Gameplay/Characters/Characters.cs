using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Game.Gameplay.Characters
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Characters")]
    public class Characters : ScriptableObject
    {
        [SerializeField]
        List<CharacterData> HiredCharacters = new List<CharacterData>();

        public int Count => HiredCharacters.Count;

        public IEnumerable<CharacterData> GetHiredCharacters()
        {
            return HiredCharacters;
        }

    }
}
