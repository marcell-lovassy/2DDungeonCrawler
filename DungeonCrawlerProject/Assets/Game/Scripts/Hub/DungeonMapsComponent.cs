using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Game.UI;
using System.Linq;
using System;
using UniRx;

namespace Assets.Game.Hub
{
    public class DungeonMapsComponent : MonoBehaviour
    {
        [SerializeField]
        private TeamPanelComponent teamPanel;

        private List<DungeonStarterComponent> dungeonStarters;

        private void Start()
        {
            dungeonStarters = GetComponentsInChildren<DungeonStarterComponent>(true).ToList();
            dungeonStarters.ForEach(d => d.SetButton(false));
            teamPanel.TeamChanged.Subscribe(OnTeamChanged);
        }

        private void OnTeamChanged(Unit obj)
        {
            if (teamPanel.IsTeamReady())
            {
                dungeonStarters.ForEach(d => d.SetButton(true));
            }
        }
    }
}

