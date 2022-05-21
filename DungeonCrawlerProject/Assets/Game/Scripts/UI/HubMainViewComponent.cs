using Com.LuisPedroFonseca.ProCamera2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.UI
{
    public class HubMainViewComponent : ViewBaseComponent
    {
        public override bool IsBlocking { get; set; } = false;

        [field: SerializeField]
        public override List<ViewBaseComponent> childViews { get; set; }

        protected override void Awake()
        {
            base.Awake();
        }
    }
}
