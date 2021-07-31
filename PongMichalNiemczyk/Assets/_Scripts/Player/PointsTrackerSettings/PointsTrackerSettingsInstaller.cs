using UnityEngine;
using Zenject;

namespace _Scripts.Players
{
    [CreateAssetMenu(menuName = "Settings/Create Points Tracker Settings")]
    public class PointsTrackerSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private PointsTrackerSettings _pointsTrackerSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(_pointsTrackerSettings);
        }
    }
}