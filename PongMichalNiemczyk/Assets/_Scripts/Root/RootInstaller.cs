using Zenject;

namespace _Scripts.Root
{
    public class RootInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Root>().AsSingle();
        }
    }
}