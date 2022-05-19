using Com.LuisPedroFonseca.ProCamera2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.UI
{
    public class HubMainViewComponent : MonoBehaviour
    {
        [SerializeField]
        private ProCamera2DRooms roomsCam;
        public ProCamera2DRooms GetRoomCamera()
        {
            return roomsCam;
        }
    }
}
