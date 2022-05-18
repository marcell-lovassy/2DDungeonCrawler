using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.UI
{
    public class HubUIComponent : MonoBehaviour
    {
        [SerializeField]
        GameObject hubMenuView;

        [SerializeField]
        GameObject mapView;

        private void Start()
        {
            SetInitialState();
        }

        public void OpenMapView()
        {
            hubMenuView.SetActive(false);
            mapView.SetActive(true);
        }

        public void CloseMapView()
        {
            mapView.SetActive(false);
            hubMenuView.SetActive(true);
        }

        private void SetInitialState()
        {
            mapView.SetActive(false);
            hubMenuView.SetActive(true);
        }
    }
}
