using Assets.Game.Gameplay.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class MouseController : MonoBehaviour
{
    [Inject]
    SelectionHandler selectionHandler;

    Camera camera;
    int screenHeight = Screen.height;

    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //0: left, 1: right, 2: middle
        {
            RaycastMouseLeftClick(Input.mousePosition);
        }
    }

    void RaycastMouseLeftClick(Vector3 mousePointerPosition)
    {
        Ray ray = camera.ScreenPointToRay(camera.ScreenToWorldPoint(mousePointerPosition));
        RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(mousePointerPosition), Vector2.zero);

        var uiHits = HitUI(mousePointerPosition);

        if (uiHits.Count > 0) return;

        if (hit)
        {
            Selectable s = null;
            if ((s = hit.collider.gameObject.GetComponent<Selectable>()) != null)
            {
                s.Select();
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
