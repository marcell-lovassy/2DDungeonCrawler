using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Gameplay.Common
{
    public class SelectionHandler
    {
        ISelectable lastSekectedObject;

        public void SelectionChanged(ISelectable selectable)
        {
            if (lastSekectedObject != selectable)
            {
                lastSekectedObject?.Deselect();
                lastSekectedObject = selectable;
            }
        }

    }
}
