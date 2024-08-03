using Towerfall.Databases;
using Towerfall.Managers;
using Towerfall.Managers.Properties;
using UnityEngine;
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
            InstallPlayerProperties();
        }

        private void InstallPlayerProperties()
        {
            InstallPlayerPropertiesModules();

            Container.BindInterfacesTo<PlayerProperties>().FromScriptableObject(_playerProperties).AsSingle();
        }

        private void InstallPlayerPropertiesModules()
        {
            Container.BindInterfacesTo<PlayerJumpProperties>().FromScriptableObject(_playerProperties.JumpProperties).AsSingle();
            Container.BindInterfacesTo<PlayerDashProperties>().FromScriptableObject(_playerProperties.DashProperties).AsSingle();
            Container.BindInterfacesTo<PlayerMovementProperties>().FromScriptableObject(_playerProperties.MovementProperties).AsSingle();
            Container.BindInterfacesTo<PlayerGravityProperties>().FromScriptableObject(_playerProperties.GravityProperties).AsSingle();
            Container.BindInterfacesTo<PlayerCombatProperties>().FromScriptableObject(_playerProperties.CombatProperties).AsSingle();
        }
    }
}
