using UnityEngine;
using Zenject;

namespace Assets.Core.IOC
{
    public class GlobalMonoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameManagement.LevelManager>().AsSingle().NonLazy();
        }
    }
}
