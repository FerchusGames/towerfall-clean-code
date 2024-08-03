using Towerfall.Databases;
using Towerfall.Managers;
using Towerfall.Managers.Properties;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Towerfall
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private PlayerProperties _playerProperties;
        
        public override void InstallBindings()
        {
            InstallScriptableObjectBindings();
            InstallDatabaseBindings();
            InstallManagerBindings();
        }

        private void InstallManagerBindings()
        {
            Container.BindInterfacesTo<PlayerManager>().AsSingle();
            Container.BindInterfacesTo<StageManager>().AsSingle();
            Container.BindInterfacesTo<InputManager>().AsSingle();
        }

        private void InstallDatabaseBindings()
        {
            Container.BindInterfacesTo<OptionsDatabase>().AsSingle();
            Container.BindInterfacesTo<PlayerProgressionDatabase>().AsSingle();
            Container.BindInterfacesTo<StatsDatabase>().AsSingle();
        }

        private void InstallScriptableObjectBindings()
        {
            Container.BindInterfacesTo<PlayerProperties>().FromScriptableObject(_playerProperties).AsSingle();
        }
    }
}
