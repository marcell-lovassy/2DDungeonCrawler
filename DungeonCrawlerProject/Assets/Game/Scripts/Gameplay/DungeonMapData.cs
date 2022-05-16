using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace Assets.Game.Gameplay
{
    [CreateAssetMenu(menuName = "ScriptableObjects/DungeonMapData")]
    public class DungeonMapData : ScriptableObject
    {
        [SerializeField]
        DungeonLocation location;
        [SerializeField]
        string dungeonName;
        [SerializeField]
        int dungeonIndex;
    }
    public enum DungeonLocation
    {
        Tower,
        Castle,
        Swamp,
        Woods,
        Cave,
    }
}

