using UnityEngine;
using Zenject;

namespace _Scripts.Audio
{
    [CreateAssetMenu(menuName = "Settings/Create Sound Settings")]
    public class SoundSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private SoundSettings _soundSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(_soundSettings).AsSingle();
        }
    }
}