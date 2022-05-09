using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Gameplay.Common
{
    public class SelectablePlayerCharacter : Selectable
    {
        public override void Select()
        {
            base.Select();
        }

        public override void Deselect()
        {
            base.Deselect();
        }

        public override void HighlightHover()
        {
            base.HighlightHover();
        }
    }
}
