﻿using System;
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
        string characterName;

        //Animator characterAnimator;

        private void Awake()
        {
            //characterAnimator = GetComponent<Animator>();
        }
    }
}
