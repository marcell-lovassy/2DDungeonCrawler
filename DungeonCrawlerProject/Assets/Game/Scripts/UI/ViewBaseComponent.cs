using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.UI
{
    public abstract class ViewBaseComponent : MonoBehaviour
    {
        private bool blocked;
        public List<Button> Buttons { get; set; }
        public abstract bool IsBlocking { get; set; }

        public abstract List<ViewBaseComponent> childViews { get; set; }

        protected virtual void Awake()
        {
            Buttons = GetComponentsInChildren<Button>().ToList();
        }

        public bool Blocked
        {
            get
            {
                return blocked;
            }
            set
            {
                blocked = value;
                ToogleButtons(blocked);
            }
        }

        private void ToogleButtons(bool blocked)
        {
            foreach (var b in Buttons)
            {
                b.enabled = !blocked;
            }
        }

        public void Block()
        {
            Blocked = true;
        }

        public void Unblock()
        {
            Blocked = false;
        }

        public virtual void Open()
        {
            gameObject.SetActive(true);
        }

        public virtual void Close()
        {
            foreach (var view in childViews)
            {
                view.Close();
            }
            gameObject.SetActive(false);
        }
    }
}
