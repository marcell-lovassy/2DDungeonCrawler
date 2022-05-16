using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Gameplay
{
    public class MapView : MonoBehaviour
    {
        [Header("UI")]

        [SerializeField]
        [Range(3, 6)]
        int dungeonsInRow = 3;

        [SerializeField]
        GameObject container;

        [Header("Data")]
        [SerializeField]
        List<DungeonMaps> allDungeonMap;

        [SerializeField]
        DungeonMapElement mapElement;

        float startpointX = -500;
        float startpointY = 500;

        float mapDistanceX = 250;
        float mapDistanceY = 250;

        Vector2 currentPosition;
        int locationInRow = 0;

        private int actualmapIndex = 0;

        private void Awake()
        {
            currentPosition = new Vector2(startpointX, startpointY);
        }

        public void SetData(List<DungeonMaps> maps)
        {
            allDungeonMap = maps;
            ShowMap(0);
        }

        private void ShowMap(int mapIndex)
        {
            foreach (var dungeon in allDungeonMap[mapIndex].Dungeons)
            {
                CreateMapItem(dungeon);
            }
        }

        private void CreateMapItem(DungeonMapData dungeon)
        {
            var mapElementInstance = Instantiate(mapElement, container.transform);
            mapElementInstance.transform.GetComponent<RectTransform>().localPosition = currentPosition;
            if(locationInRow == dungeonsInRow)
            {
                locationInRow = 0;
                currentPosition = new Vector2(startpointX, currentPosition.y - mapDistanceY);
            }
            else
            {
                locationInRow++;
                currentPosition += new Vector2(mapDistanceX, 0);
            }

            mapElementInstance.SetDungeonData(dungeon);
        }
    }
}
