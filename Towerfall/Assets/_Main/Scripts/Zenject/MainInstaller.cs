using Towerfall.Databases;
using Towerfall.Managers;
using Zenject;

namespace Towerfall
{
    public class MainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            // DATABASES
            Container.BindInterfacesTo<OptionsDatabase>().AsSingle();
            Container.BindInterfacesTo<PlayerProgressionDatabase>().AsSingle();
            Container.BindInterfacesTo<StatsDatabase>().AsSingle();
            
            //MANAGERS
            Container.BindInterfacesTo<PlayerManager>().AsSingle();
            Container.BindInterfacesTo<InputManager>().AsSingle();
            Container.BindInterfacesTo<StageManager>().AsSingle();
        }
    }
}
