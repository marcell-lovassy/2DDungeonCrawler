using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Gameplay.Characters
{
    [Serializable]
    public class CharacterStats
    {
        [SerializeField]
        int maxHealth;
        [SerializeField]
        int armor;
        [SerializeField]
        int initiative;
    }
}

