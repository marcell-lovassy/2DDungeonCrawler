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
            SaveGameData();
        }


        private SessionData LoadGameData()
        {
            //var gameData = ES3.Load<SessionData>("Profile1", new SessionData());
            //return gameData;
            return new SessionData();
        }

        public void SaveGameData()
        {
            //sessionData.goldAmount = 10;
            //ES3.Save<SessionData>("Profile1", sessionData);
        }
    }
}
