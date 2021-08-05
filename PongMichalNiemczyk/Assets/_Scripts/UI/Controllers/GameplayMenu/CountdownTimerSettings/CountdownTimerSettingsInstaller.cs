using UnityEngine;
using Zenject;

namespace _Scripts.UI
{
    [CreateAssetMenu(menuName = "Settings/Create Countdown Timer Settings")]
    public class CountdownTimerSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private CountdownTimerSettings _countdownTimerSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(_countdownTimerSettings);
        }
    }
}