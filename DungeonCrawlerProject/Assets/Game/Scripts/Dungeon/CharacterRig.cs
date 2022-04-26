using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game.Dungeon
{
    public class CharacterRig : MonoBehaviour
    {
        [SerializeField]
        float slotDistance;

        [SerializeField]
        CharacterSlot[] characterSlots = new CharacterSlot[4];

    }
}
