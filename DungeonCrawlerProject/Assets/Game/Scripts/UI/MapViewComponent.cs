using Assets.Core.GameManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Game.UI
{
    public class MapViewComponent : ViewBaseComponent
    {

        public override bool IsBlocking { get; set; } = true;

        protected override void Awake()
        {
            base.Awake();
        }
    }
}

