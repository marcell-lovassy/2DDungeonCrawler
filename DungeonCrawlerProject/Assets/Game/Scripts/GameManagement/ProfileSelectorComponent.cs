using Assets.Core.GameManagement;
using Assets.Game.Data;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Game.GameManagement
{
    public class ProfileSelectorComponent : MonoBehaviour
    {
        public void LoadProfile(Profile profile)
        {
            SaveSystem.Instance.SetSessionData(ES3.Load<SessionData>(profile.Name));
        }
    }
}
