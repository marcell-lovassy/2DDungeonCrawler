using Assets.Game.Data;
using UnityEngine;
using Zenject;


namespace Assets.Game.Installers
{
    public class SessionInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SessionData>().FromInstance(new SessionData()).AsSingle().NonLazy();
        }
    }
}