using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Gameplay
{
    public class DungeonMapElement : MonoBehaviour
    {
        [SerializeField]
        Sprite dungeonIconSprite;

        [SerializeField]
        TMP_Text dungeonNameText;

        [SerializeField]
        Image dungeonIcon;

        private DungeonMapData mapData;

        public void SetDungeonData(DungeonMapData data)
        {
            mapData = data;

            dungeonNameText.text = data.dungeonName;
            dungeonIcon.sprite = SelectIcon(mapData);
        }

        private Sprite SelectIcon(DungeonMapData mapData)
        {
            switch (mapData.location)
            {
                default:
                    return dungeonIconSprite;
            }
        }
    }
}
