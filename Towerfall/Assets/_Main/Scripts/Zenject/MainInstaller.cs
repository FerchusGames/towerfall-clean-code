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
            //SCRIPTABLE OBJECTS
            Container.BindInterfacesTo<PlayerProperties>().FromScriptableObject(_playerProperties).AsSingle();
            
            // DATABASES
            Container.BindInterfacesTo<OptionsDatabase>().AsSingle();
            Container.BindInterfacesTo<PlayerProgressionDatabase>().AsSingle();
            Container.BindInterfacesTo<StatsDatabase>().AsSingle();
            
            //MANAGERS
            Container.BindInterfacesTo<PlayerManager>().AsSingle();
            Container.BindInterfacesTo<StageManager>().AsSingle();
            Container.BindInterfacesTo<InputManager>().AsSingle();
        }
    }
}
