using Zenject;

namespace _Scripts.UI
{
    public class UIControllerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UIController>().AsSingle();
        }
    }
}