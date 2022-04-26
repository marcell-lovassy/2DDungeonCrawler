﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game.GameState
{
    public abstract class GameState : MonoBehaviour, IGameState
    {
        public IGameState SetupGameState()
        {
            throw new NotImplementedException();
        }
    }
}
