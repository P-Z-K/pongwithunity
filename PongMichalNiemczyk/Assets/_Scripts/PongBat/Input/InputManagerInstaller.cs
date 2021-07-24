using UnityEngine;
using Zenject;

namespace _Scripts
{
    public class InputManagerInstaller : MonoInstaller
    {
        [SerializeField] private InputManager _inputManager;
        public override void InstallBindings()
        {
            Container.BindInstance(_inputManager).AsSingle();
        }
    }
}