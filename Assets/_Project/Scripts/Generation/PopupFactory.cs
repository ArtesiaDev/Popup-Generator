using System.Threading.Tasks;
using _Project.Scripts.Popup;
using _Project.Scripts.Services.AssetManagement;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Generation
{
    public sealed class PopupFactory
    {
        private const string POPUP = "Popup";
        private IAssetProvider _assetProvider;
        private DiContainer _container;
        private readonly RectTransform _parent;

        [Inject]
        private void Construct(DiContainer container, IAssetProvider assetProvider)
        {
            _container = container;
            _assetProvider = assetProvider;
        }

        public async Task Prepare() =>
            await _assetProvider.Load<GameObject>(key: POPUP);


        public async Task<PopupView> Create(Transform parent, Vector3 position)
        {
            var posCorrection = new Vector3(0f, 210f, 0f);
            var prefab = await _assetProvider.Load<GameObject>(key: POPUP);
            return _container.InstantiatePrefabForComponent<PopupView>(prefab, position + posCorrection, Quaternion.identity, parent);
        }

        public void Clear() =>
            _assetProvider.Release(key: POPUP);
    }
}