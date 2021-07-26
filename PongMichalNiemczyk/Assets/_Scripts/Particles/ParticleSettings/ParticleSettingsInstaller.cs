using UnityEngine;
using Zenject;

namespace _Scripts.Particles.ParticleSettings
{
    [CreateAssetMenu(menuName = "Settings/Create Particle Settings")]
    public class ParticleSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private ParticleSettings _particleSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(_particleSettings);
        }
    }
}