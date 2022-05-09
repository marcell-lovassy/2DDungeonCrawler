using UnityEngine;
using Zenject;
using Assets.Game.Gameplay.Common;

public class DungeonInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<SelectionHandler>().FromInstance(new SelectionHandler()).AsSingle().NonLazy();
    }
}