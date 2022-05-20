using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Data
{
    [CreateAssetMenu(menuName = "ScriptableObjects/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField]
        string saveFileWithRelativePath;
    }
}

