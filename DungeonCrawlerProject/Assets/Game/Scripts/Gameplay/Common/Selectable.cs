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
        List<Renderer> renderers;

        [SerializeField]
        Material hoverMaterial;

        [SerializeField]
        Material selectedMaterial;

        Material baseMaterial;

        public bool IsSelected { get; private set; }

        [Inject]
        protected SelectionHandler selectionHandler;

        private void Awake()
        {
            baseMaterial = renderers[0].material;
        }

        private void OnMouseEnter()
        {
            if (!IsSelected && !selectionHandler.SelectionBlocked)
            {
                HighlightHover();
            }
        }

        private void OnMouseExit()
        {
            if(!IsSelected) renderers.ForEach(r => r.material = baseMaterial);
        }

        public virtual void Select()
        {
            //TODO: create a selection manager, to handle the deselection etc.
            renderers.ForEach(r => r.material = selectedMaterial);
            IsSelected = true;
            selectionHandler.SelectionChanged(this);
        }

        public virtual void Deselect()
        {
            //TODO: deselect if something else is selected
            //-> selectionManager is needed that knows the previously selected object etc.
            //renderer.material = baseMaterial;
            renderers.ForEach(r => r.material = baseMaterial);
            IsSelected = false;
        }

        public virtual void HighlightHover()
        {
            //renderer.material = hoverMaterial;
            renderers.ForEach(r => r.material = hoverMaterial);
        }
    }
}

