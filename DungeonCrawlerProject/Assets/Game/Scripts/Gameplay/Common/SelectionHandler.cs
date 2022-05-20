﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Gameplay.Common
{
    public class SelectionHandler
    {
        ISelectable lastSelectedObject;

        public bool SelectionBlocked { get; private set; }

        public void SelectionChanged(ISelectable selectable)
        {
            if (lastSelectedObject != selectable)
            {
                lastSelectedObject?.Deselect();
                lastSelectedObject = selectable;
            }
        }

        public void BlockSelection()
        {
            SelectionBlocked = true;
        }

        public void UnblockSelection()
        {
            SelectionBlocked = false;
        }
    }
}
