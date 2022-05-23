using Assets.Game.Gameplay.Common;
using UnityEngine;
using Zenject;


namespace Assets.Game.Installers
{
    public class HubInstaller : MonoInstaller
    {
        [SerializeField]
        MouseController2D mouseController2DPrefab;

        [SerializeField]
        MouseController3D mouseController3DPrefab;

        public override void InstallBindings()
        {
            Container.Bind<SelectionHandler>().FromInstance(new SelectionHandler()).AsSingle().NonLazy();
            Container.Bind<MouseController2D>().FromComponentInNewPrefab(mouseController2DPrefab).AsSingle().NonLazy();
            //Container.Bind<MouseController3D>().FromComponentInNewPrefab(mouseController3DPrefab).AsSingle().NonLazy();
        }
    }
}
