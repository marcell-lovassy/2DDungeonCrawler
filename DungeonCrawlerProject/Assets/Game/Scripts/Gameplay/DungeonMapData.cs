using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace Assets.Game.Gameplay
{
    [Serializable]
    [CreateAssetMenu(menuName = "ScriptableObjects/DungeonMapData")]
    public class DungeonMapData : ScriptableObject
    {
        public DungeonLocation location;
        public string dungeonName;
        public int dungeonIndex;
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

