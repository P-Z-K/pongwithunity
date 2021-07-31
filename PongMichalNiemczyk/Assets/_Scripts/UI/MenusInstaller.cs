using UnityEngine;
using Zenject;

namespace _Scripts.UI
{
    public class MenusInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<MenuManager>().AsSingle();
            Container.Bind<UI_PointsTracker>().AsSingle();
        }
    }
}