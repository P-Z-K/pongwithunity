using UnityEngine;
using Zenject;

namespace _Scripts.PongBat
{
    [CreateAssetMenu(menuName = "Settings/Create PongBat Settings")]
    public class PongBatSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private PongBatSettings _pongBatSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(_pongBatSettings).AsSingle();
        }
    }
}