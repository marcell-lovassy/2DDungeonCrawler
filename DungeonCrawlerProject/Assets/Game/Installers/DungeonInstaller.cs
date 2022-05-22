using UnityEngine;
using Zenject;
using Assets.Game.Gameplay.Common;

namespace Assets.Game.Installers
{
    public class DungeonInstaller : MonoInstaller
    {
        [SerializeField]
        MouseController2D mouseController2DPrefab;

        [SerializeField]
        MouseController3D mouseController3DPrefab;

        public override void InstallBindings()
        {
            Container.Bind<SelectionHandler>().FromInstance(new SelectionHandler()).AsSingle().NonLazy();
            Container.Bind<MouseController3D>().FromComponentInNewPrefab(mouseController3DPrefab).AsSingle().NonLazy();
        }
    }
}
