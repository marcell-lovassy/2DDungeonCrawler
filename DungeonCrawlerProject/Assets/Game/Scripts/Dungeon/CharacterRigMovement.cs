using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Game.Dungeon
{
    public class CharacterRigMovement : MonoBehaviour
    {
        [SerializeField]
        float speed = 2f;

        CharacterRig rig;
        CharacterSlot leadingSlot;

        private void Start()
        {
            rig = GetComponent<CharacterRig>();
            leadingSlot = rig.GetLeadingSlot();
        }

        void Update()
        {
            var horizontalMovement = Input.GetAxis("Horizontal");
            leadingSlot.transform.position += new Vector3(horizontalMovement *  speed * Time.deltaTime, 0f);
        }
    }
}

