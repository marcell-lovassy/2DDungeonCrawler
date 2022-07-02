using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace Assets.Game.Hub
{
    public class TeamPanelComponent : MonoBehaviour
    {
        public IObservable<Unit> TeamChanged => teamChanged;
        private Subject<Unit> teamChanged = new Subject<Unit>();

        [SerializeField]
        List<CharacterSelectionSlotComponent> characterSelectionSlotComponents = new List<CharacterSelectionSlotComponent>();

        private CompositeDisposable disposables;

        private void Start()
        {
            disposables?.Dispose();
            disposables = new CompositeDisposable();
            characterSelectionSlotComponents.ForEach(c => c.SelectedCharacterCahnged.Subscribe(_ => teamChanged.OnNext(Unit.Default)).AddTo(disposables));
        }

        public bool IsTeamReady()
        {
            return characterSelectionSlotComponents.All(slot => slot.IsSet());
        }

        private void OnDestroy()
        {
            disposables?.Dispose();
        }
    }
}
