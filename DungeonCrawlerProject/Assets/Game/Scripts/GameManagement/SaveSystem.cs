using Assets.Game.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Game.GameManagement
{
    /// <summary>
    /// Starts when the game starts - it is created by the ProjectContext immediately (NonLazy)
    /// There is one SaveSystem in the whole game session
    /// </summary>
    public class SaveSystem : MonoBehaviour
    {
        [Inject]
        SessionData sessionData;

        public static SaveSystem Instance;

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            //load the save data or create a popup to select profile
            //(if there is a multi profile implementation)
            sessionData = LoadGameData();
        }


        private SessionData LoadGameData()
        {
            return new SessionData();
        }

        public void SaveGameData()
        {

        }
    }
}
