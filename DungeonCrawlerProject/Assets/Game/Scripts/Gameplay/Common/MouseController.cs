using Assets.Game.Gameplay.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

}
