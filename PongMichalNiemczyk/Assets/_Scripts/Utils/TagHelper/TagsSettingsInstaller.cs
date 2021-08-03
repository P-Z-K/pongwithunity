using UnityEngine;
using Zenject;

namespace _Scripts.Utils
{
    [CreateAssetMenu(menuName = "Settings/Create Tags Settings")]
    public class TagsSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private TagsSettings _tagsSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(_tagsSettings).AsSingle();
        }
    }
}