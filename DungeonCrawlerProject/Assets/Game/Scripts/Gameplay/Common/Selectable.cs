using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AllIn1SpriteShader;
using Zenject;

namespace Assets.Game.Gameplay.Common
{
    public abstract class Selectable : MonoBehaviour, ISelectable
    {
        [SerializeField]
        Renderer renderer;

        [SerializeField]
        Material hoverMaterial;

        [SerializeField]
        Material selectedMaterial;

        Material baseMaterial;

        public bool IsSelected { get; private set; }

        [Inject]
        SelectionHandler selectionHandler;

        private void Awake()
        {
            baseMaterial = renderer.material;
        }

        private void OnMouseEnter()
        {
            if(!IsSelected) HighlightHover();
        }

        private void OnMouseExit()
        {
            if(!IsSelected) renderer.material = baseMaterial;
        }

        public virtual void Select()
        {
            //TODO: create a selection manager, to handle the deselection etc.
            renderer.material = selectedMaterial;
            IsSelected = true;
            selectionHandler.SelectionChanged(this);
        }

        public virtual void Deselect()
        {
            //TODO: deselect if something else is selected
            //-> selectionManager is needed that knows the previously selected object etc.
            renderer.material = baseMaterial;
            IsSelected = false;
        }

        public virtual void HighlightHover()
        {
            renderer.material = hoverMaterial;
        }
    }
}

