using Scripts.EventSignals;
using Scripts.Services.AssetManagement;
using Zenject;

namespace Scripts.Installers
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