using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Game.Dungeon;
using Assets.Core.GameManagement;
using Assets.Game.Gameplay.Characters;
using System.Linq;

namespace Assets.Game.GameManagement
{
    /// <summary>
    /// This component is responsible for the data transfer from the HUB to the Dungeon
    /// Select characters from the UI -> add them to this component as well... etc
    /// </summary>
    public class DungeonDataProviderComponent : MonoBehaviour
    {
        //TODO: these should not be serialized fields
        [SerializeField]
        DungeonCharacter[] selectedCharacters = new DungeonCharacter[4];

        [SerializeField]
        CharacterData[] characterData = new CharacterData[4];

        [SerializeField]
        List<DungeonReward> rewards;

        DungeonLevelData dungeonData;

        public static DungeonDataProviderComponent Instance;

        private void Awake()
        {
            Instance = this;
            dungeonData = new DungeonLevelData();
        }

        // Start is called before the first frame update
        void Start()
        {
            GameManagerComponent.Instance.levelDataObject = dungeonData;
        }

        public void SetCharacterData(int characterIndex, CharacterData data)
        {
            characterData[characterIndex] = data;
            dungeonData.DungeonCharacterData[characterIndex] = data;
        }

        public void SetDungeonData(DungeonLevelData data)
        {
            dungeonData = data;
        }

        public bool IsCharacterSelected(CharacterData data)
        {
            return characterData.Contains(data);
        }
    }
}
