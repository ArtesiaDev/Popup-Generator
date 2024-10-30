using _Project.Scripts.Generation;
using _Project.Scripts.Popup;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Installers
{
    public class SceneContextInstaller : MonoInstaller
    {
        [SerializeField] private UIView _uIView;
        [SerializeField] private PopupCreator _popupCreator;

        public override void InstallBindings()
        {
            Container.Bind<UIView>().FromInstance(_uIView);
            Container.BindInterfacesAndSelfTo<UIController>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<PopupController>().AsSingle();

            Container.Bind<PopupFactory>().AsSingle().NonLazy();
            Container.Bind<SpriteFactory>().AsSingle().NonLazy();
            Container.Bind<PopupCreator>().FromInstance(_popupCreator).AsSingle();
        }
    }
}