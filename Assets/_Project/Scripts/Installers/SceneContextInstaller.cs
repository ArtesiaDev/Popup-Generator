using Scripts.Generation;
using Scripts.Goods;
using Scripts.Popup;
using UnityEngine;
using Zenject;

namespace Scripts.Installers
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
            Container.BindInterfacesAndSelfTo<GoodsController>().AsSingle();

            Container.Bind<PopupFactory>().AsSingle().NonLazy();
            Container.Bind<GoodsFactory>().AsSingle().NonLazy();
            Container.Bind<SpriteFactory>().AsSingle().NonLazy();
            Container.Bind<PopupCreator>().FromInstance(_popupCreator).AsSingle();
        }
    }
}