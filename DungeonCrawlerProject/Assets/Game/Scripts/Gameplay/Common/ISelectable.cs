using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Gameplay.Common
{
    public interface ISelectable
    {
        public bool IsSelected { get; }
        void Select();
        void Deselect();
        void HighlightHover();
    }
}
