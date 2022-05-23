using Assets.Game.Gameplay.Common;
using Assets.Game.UI;
using Com.LuisPedroFonseca.ProCamera2D;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerBaseComponent : MonoBehaviour
{
    [SerializeField]
    ProCamera2DRooms roomsCam;

    public int selectedRoom => roomsCam.CurrentRoomIndex;

    [SerializeField]
    RectTransform content;

    [SerializeField]
    FloorShortcutButton buttonPrefab;

    List<SelectableTowerLevel> towerLevels;

    public delegate void GoToFloorAction(string floorName);

    public GoToFloorAction action;

    private int camRoomCorrection = 0;

    private void Start()
    {
        towerLevels = GetComponentsInChildren<SelectableTowerLevel>().ToList();

        //roomsCam.EnterRoom(0);
        action = EnterRoom;
        FillFloorNavigation();

        camRoomCorrection = Mathf.Abs(towerLevels.Count - roomsCam.Rooms.Count);
    }

    public void EnterRoom(int room)
    {
        if(!towerLevels.ElementAt(room).IsSelected) towerLevels.ElementAt(room).Select();
        roomsCam.EnterRoom(room + camRoomCorrection);
    }

    internal void ExitRoom()
    {
        roomsCam.ExitRoom();
    }

    public void EnterRoom(string room)
    {
        towerLevels.FirstOrDefault(t => t.GetName() == room).Select();
        roomsCam.EnterRoom(room);
    }


    private void FillFloorNavigation()
    {
        content.sizeDelta = new Vector2 (content.sizeDelta.x, towerLevels.Count * (buttonPrefab.transform as RectTransform).rect.height);
        FloorShortcutButton previousButton = null;
        foreach (var level in towerLevels)
        {
            var button = Instantiate(buttonPrefab, content);
            if(previousButton != null)
            {
                var t = button.transform as RectTransform;
                var pt = previousButton.transform as RectTransform;
                t.anchoredPosition += new Vector2(0, pt.anchoredPosition.y + pt.rect.height + 20); 
            }
            button.SetupButton(level.GetName(), action);

            previousButton = button;
        }
      
    }
}
