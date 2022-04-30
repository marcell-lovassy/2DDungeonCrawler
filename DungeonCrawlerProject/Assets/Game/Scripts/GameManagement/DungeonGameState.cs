using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Core.GameManagement;


namespace Assets.Game.GameManagement
{
    public class DungeonGameState : GameState
    {
        public override string StateMusic => "none";

        public override IGameState SetupGameState()
        {
            throw new System.NotImplementedException();
        }
    }
}
