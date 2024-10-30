using _Project.Scripts.EventSignals;
using _Project.Scripts.Services.AssetManagement;
using Zenject;

namespace _Project.Scripts.Installers
{
    public class ProjectContextInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<AssetProvider>().AsSingle().NonLazy();
            Container.BindInterfacesTo<PopupSignals>().AsSingle();
        }
    }
}