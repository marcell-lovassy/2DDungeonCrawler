using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Gameplay
{
    [CreateAssetMenu(menuName = "ScriptableObjects/DungeonMaps")]
    public class DungeonMaps : ScriptableObject
    {
        public List<DungeonMapData> Dungeons;
    }
}

