using UnityEngine;
using Zenject;

namespace Assets.Core.IOC
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField]
        GameObject gameManagerObject;

        public override void InstallBindings()
        {
            Container.Bind<GameManagement.GameManagerComponent>().
                FromComponentInNewPrefab(gameManagerObject).AsSingle().NonLazy();
            Container.Bind<GameManagement.LevelManager>().AsSingle().NonLazy();
        }
    }
}
