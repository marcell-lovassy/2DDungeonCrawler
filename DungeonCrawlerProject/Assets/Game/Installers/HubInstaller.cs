using Assets.Game.Gameplay.Common;
using UnityEngine;
using Zenject;

public class HubInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<SelectionHandler>().FromInstance(new SelectionHandler()).AsSingle().NonLazy();
    }
}