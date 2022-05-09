using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Game.Gameplay.Common;
using Zenject;

namespace Assets.Game.Dungeon
{
    public class CharacterRigMovement : MonoBehaviour
    {
        [SerializeField]
        float speed = 2f;

        CharacterRig rig;
        CharacterSlot leadingSlot;

        Camera camera;

        [Inject]
        SelectionHandler selectionHandler;

        private void Start()
        {
            rig = GetComponent<CharacterRig>();
            leadingSlot = rig.GetLeadingSlot();
            camera = Camera.main;
        }

        void Update()
        {

            if (Input.GetMouseButtonDown(0)) //0: left, 1: right, 2: middle
            {
                RaycastMouseLeftClick(Input.mousePosition);
            }
            var horizontalMovement = Input.GetAxis("Horizontal");
            leadingSlot.transform.position += new Vector3(horizontalMovement *  speed * Time.deltaTime, 0f);
        }

        void RaycastMouseLeftClick(Vector3 mousePointerPosition)
        {
            Ray ray = camera.ScreenPointToRay(camera.ScreenToWorldPoint(mousePointerPosition));
            RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(mousePointerPosition), Vector2.zero);

            if (hit)
            {
                Selectable s = null;
                if((s = hit.collider.gameObject.GetComponent<Selectable>()) != null)
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
}

