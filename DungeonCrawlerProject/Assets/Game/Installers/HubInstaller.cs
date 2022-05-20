using Assets.Game.Gameplay.Common;
using UnityEngine;
using Zenject;


namespace Assets.Game.Installers
{
    public class HubInstaller : MonoInstaller
    {
        [SerializeField]
        MouseController mouseControllerPrefab;

        public override void InstallBindings()
        {
            Container.Bind<SelectionHandler>().FromInstance(new SelectionHandler()).AsSingle().NonLazy();
            Container.Bind<MouseController>().FromComponentInNewPrefab(mouseControllerPrefab).AsSingle().NonLazy();
        }
    }
}
