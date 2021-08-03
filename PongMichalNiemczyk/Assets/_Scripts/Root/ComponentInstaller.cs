using System;
using Zenject;

namespace _Scripts.Root
{
    public class ComponentInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BallComponent>().AsSingle();
            Container.Bind<ParticleEntityManagerComponent>().AsSingle();
            Container.Bind<SoundEntityManagerComponent>().AsSingle();
            Container.Bind<PongBatComponent>().AsSingle();
            Container.Bind<PointsTrackerComponent>().AsSingle();
            Container.Bind<GameplayMenuComponent>().AsSingle();
            Container.Bind<StartMenuComponent>().AsSingle();
            Container.Bind<GameOverMenuComponent>().AsSingle();
        }
    }
}