using UnityEngine;
using Zenject;

namespace _Scripts.Root.GameSettings
{
    [CreateAssetMenu(menuName = "Settings/Create Game Settings")]
    public class GameSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private GameSettings _gameSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(_gameSettings);
        }
    }
}