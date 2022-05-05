using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Game.Dungeon;
using Assets.Core.GameManagement;

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
        List<DungeonCharacter> selectedCharacters;

        [SerializeField]
        List<DungeonReward> rewards;

        DungeonLevelData dungeonData;

        private void Awake()
        {
            //TODO: these sould be in a setLevelData method, for now it is in Awake for testing
            dungeonData = new DungeonLevelData();
            dungeonData.DungeonCharacters = selectedCharacters;
            dungeonData.Rewards = rewards;
        }

        // Start is called before the first frame update
        void Start()
        {
            GameManagerComponent.Instance.levelDataObject = dungeonData;
        }
    }
}
