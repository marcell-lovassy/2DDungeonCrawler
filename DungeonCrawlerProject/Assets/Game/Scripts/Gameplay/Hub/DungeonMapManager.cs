using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Game.Gameplay.Hub
{
    public class DungeonMapManager : MonoBehaviour
    {

        [SerializeField]
        MapView dungeonMapView;

        [SerializeField]
        List<DungeonMaps> maps;

        private void Start()
        {
            dungeonMapView.gameObject.SetActive(false);
            CreateMapFromData();
        }

        private void CreateMapFromData()
        {
            dungeonMapView.SetData(maps);
        }

        public void OpenDungeonMap()
        {
            dungeonMapView.gameObject.SetActive(true);
        }
    }
}
