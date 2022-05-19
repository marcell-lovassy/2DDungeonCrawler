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
            if (IsSelected) return;
            base.Select();
            tower.EnterRoom(towerRoomIndex);
        }

        public override void Deselect()
        {
            base.Deselect();
            tower.ExitRoom();
        }

        public override void HighlightHover()
        {
            base.HighlightHover();
        }

        public string GetName()
        {
            return towerRoomName; 
        }

    }
}
