using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Core.UI
{
    public class SplashComponent : MonoBehaviour
    {
        public void FinishSplash()
        {
            GameManagement.GameManagerComponent.Instance.LoadMenu();
        }
    }
}

