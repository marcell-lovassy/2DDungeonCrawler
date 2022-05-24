using Assets.Core.Audio;
using Assets.Game.GameManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game.Gameplay.Common
{
    public class SelectableTowerLevel : Selectable
    {
        [SerializeField]
        string towerRoomName;

        [SerializeField]
        int towerRoomIndex;

        TowerBaseComponent tower;

        private void Start()
        {
            tower = GetComponentInParent<TowerBaseComponent>();
        }

        public void SetupLevel(string name)
        {
            if(towerRoomName == null) towerRoomName = name;
        }

        public override void Select()
        {
            if (IsSelected || selectionHandler.SelectionBlocked) return;
            base.Select();
            tower.EnterRoom(towerRoomIndex);
            SceneAudioController.Instance.PlayList(towerRoomName);
        }

        public override void Deselect()
        {
            if (!IsSelected) return;
            base.Deselect();
            tower.ExitRoom();
            SceneAudioController.Instance.PauseList(towerRoomName);

        }

        public override void HighlightHover()
        {
            if (selectionHandler.SelectionBlocked) return;
            base.HighlightHover();
        }

        public string GetName()
        {
            return towerRoomName; 
        }
    }
}
