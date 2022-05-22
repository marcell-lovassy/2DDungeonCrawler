using Assets.Game.Gameplay.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

//TODO: inject it from IOC? Put it on SceneContext?
/// <summary>
/// Mouse buttons: 0: left, 1: right, 2: middle
/// </summary>
public class MouseController2D : MonoBehaviour
{
    [Inject]
    SelectionHandler selectionHandler;

    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastMouseLeftClick(Input.mousePosition);
        }
        if (Input.GetMouseButtonDown(1)) 
        {
            RaycastMouseLeftClick(Input.mousePosition, false);
        }
    }

    void RaycastMouseLeftClick(Vector3 mousePointerPosition, bool select = true)
    {
        Ray ray = cam.ScreenPointToRay(cam.ScreenToWorldPoint(mousePointerPosition));
        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(mousePointerPosition), Vector2.zero);

        var uiHits = HitUI(mousePointerPosition);

        if (uiHits.Count > 0) return;

        if (hit)
        {
            Selectable s = null;
            if ((s = hit.collider.gameObject.GetComponent<Selectable>()) != null)
            {
                if (select) s.Select();
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
