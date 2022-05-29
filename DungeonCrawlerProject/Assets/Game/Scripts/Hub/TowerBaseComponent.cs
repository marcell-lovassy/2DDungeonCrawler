using Assets.Game.Gameplay.Common;
using Assets.Game.UI;
using Com.LuisPedroFonseca.ProCamera2D;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;
using Zenject;

public class TowerBaseComponent : MonoBehaviour
{
    [Inject]
    SelectionHandler selectionHandler;


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
        selectionHandler.NoSelectionEvent.Subscribe(_ => EnterRoom("BaseRoom"));
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
        towerLevels.FirstOrDefault(t => t.GetName() == room)?.Select();
        roomsCam.EnterRoom(room);
    }


    private void FillFloorNavigation()
    {
        foreach (var level in towerLevels)
        {
            var button = Instantiate(buttonPrefab);
            button.transform.SetParent(content, false);
            button.SetupButton(level.GetName(), action);
        }
      
    }
}
