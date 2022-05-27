using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRx;
using UnityEngine.Events;

namespace Assets.Game.Gameplay.Common
{
    public class SelectionHandler
    {
        ISelectable lastSelectedObject;

        public IObservable<Unit> NoSelectionEvent => noSelection;

        private readonly Subject<Unit> noSelection = new Subject<Unit>();

        public bool SelectionBlocked { get; private set; }

        public void SelectionChanged(ISelectable selectable)
        {
            if (lastSelectedObject != selectable)
            {
                lastSelectedObject?.Deselect();
                lastSelectedObject = selectable;

                if(lastSelectedObject == null) NothingIsSelected();
            }
        }

        private void NothingIsSelected()
        {
            noSelection.OnNext(Unit.Default);
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
