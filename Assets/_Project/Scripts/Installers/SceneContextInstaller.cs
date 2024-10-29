using _Project.Scripts.Popup;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Installers
{
    public class SceneContextInstaller : MonoInstaller
    {
        [SerializeField] private UIView _uIView;
        [SerializeField] private PopupView _popupView;

        public override void InstallBindings()
        {
            Container.Bind<UIView>().FromInstance(_uIView);
            Container.BindInterfacesAndSelfTo<UIController>().AsSingle();
            
            Container.Bind<PopupView>().FromInstance(_popupView);
            Container.BindInterfacesAndSelfTo<PopupController>().AsSingle();
            Container.Bind<PopupModel>().AsSingle();
        }
    }
}