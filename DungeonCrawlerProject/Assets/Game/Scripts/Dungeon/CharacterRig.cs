﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Core.GameManagement;

namespace Assets.Game.Dungeon
{
    public class CharacterRig : MonoBehaviour
    {
        [SerializeField]
        float slotDistance;

        [SerializeField]
        CharacterSlot[] characterSlots = new CharacterSlot[4];

        DungeonLevelData dungeonData;

        private void Awake()
        {
            dungeonData = (DungeonLevelData)GameManagerComponent.Instance.levelDataObject;
        }


        private void SetupCharacters()
        {

        }

    }
}
