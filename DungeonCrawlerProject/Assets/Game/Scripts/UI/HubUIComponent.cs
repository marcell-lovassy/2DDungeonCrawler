using Assets.Game.Gameplay.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Game.UI
{
    public class HubUIComponent : MonoBehaviour
    {
        [SerializeField]
        HubMainViewComponent hubMenuView;

        [SerializeField]
        MapViewComponent mapView;

        [Inject]
        SelectionHandler SelectionHandler;

        private Stack<ViewBaseComponent> uiViewStack = new Stack<ViewBaseComponent>();

        private void Start()
        {
            SetInitialState();
        }

        //TODO: create a generic open view method with a baseview parameter
        public void OpenMapView()
        {
            mapView.Open();
            hubMenuView.gameObject.SetActive(false);
            if (mapView.IsBlocking)
            {
                SelectionHandler.BlockSelection();
            }
            PushToViewStack(mapView);
        }

        //TODO: mofify it to be something like CloseTopView generic method
        public void CloseMapView()
        {
            SelectionHandler.UnblockSelection();
            PopFromViewStack();
            mapView.Close();
            hubMenuView.gameObject.SetActive(true);
        }

        private void SetInitialState()
        {
            SelectionHandler.UnblockSelection();
            mapView.gameObject.SetActive(false);
            hubMenuView.gameObject.SetActive(true);
            PushToViewStack(hubMenuView);
        }

        private void PushToViewStack(ViewBaseComponent component)
        {
            if (uiViewStack.Count != 0 && uiViewStack.Peek() == component) return;
            if (component.IsBlocking) uiViewStack.Peek()?.Block();
            uiViewStack.Push(component);
        }
        private ViewBaseComponent PopFromViewStack()
        {
            var view = uiViewStack.Pop();
            uiViewStack.Peek().Unblock();

            return view;
        }
    }
}
