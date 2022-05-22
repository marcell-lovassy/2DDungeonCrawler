using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Assets.Game.Gameplay.Common
{
    public class MouseController3D : MonoBehaviour
    {
        [Inject]
        SelectionHandler selectionHandler;

        Camera cam;

        void Start()
        {
            cam = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastMouseClick(Input.mousePosition, 0);
            }
            if (Input.GetMouseButtonDown(1))
            {
                RaycastMouseClick(Input.mousePosition, 1);
            }
        }

        private void RaycastMouseClick(Vector3 mousePosition, int button)
        {
            var uiHits = HitUI(mousePosition);

            if (uiHits.Count > 0)
            {
                return;
            }

            Ray ray = cam.ScreenPointToRay(mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                Selectable s = null;
                if ((s = hit.collider.gameObject.GetComponent<Selectable>()) != null)
                {
                    if (button == 0) s.Select();
                    else s.Deselect();
                }
            }
            else
            {
                selectionHandler.SelectionChanged(null);
            }

        }

        private List<RaycastResult> HitUI(Vector3 pointerPosition)
        {
            var pointerEventData = new PointerEventData(EventSystem.current) { position = pointerPosition };
            var raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, raycastResults);

            return raycastResults;
        }
    }
}
