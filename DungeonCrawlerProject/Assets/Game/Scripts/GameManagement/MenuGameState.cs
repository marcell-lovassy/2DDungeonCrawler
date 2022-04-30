using Assets.Core.GameManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.GameManagement
{
    internal class MenuGameState : GameState
    {
        public override string StateMusic => "Theme";

        public override IGameState SetupGameState()
        {
            throw new NotImplementedException();
        }
    }
}
