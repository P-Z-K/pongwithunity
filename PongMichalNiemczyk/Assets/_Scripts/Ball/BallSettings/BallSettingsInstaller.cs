using UnityEngine;
using Zenject;

namespace _Scripts.Ball
{
    [CreateAssetMenu(menuName = "Settings/Create Ball Settings")]
    public class BallSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private BallSettings _ballSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(_ballSettings);
        }
    }
}