using Assets.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game.Dungeon
{
    public abstract class Loot : MonoBehaviour, ICollectable
    {
        public void Collect()
        {
            //add to player inventory if it is an item / add to the gold amount the player has if it is gold etc...


            //play collect animation


            //destray gameobject

            throw new NotImplementedException();
        }
    }
}
