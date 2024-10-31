using System.Threading.Tasks;
using Scripts.Goods;
using Scripts.Services.AssetManagement;
using UnityEngine;
using Zenject;

namespace Scripts.Generation
{
    public sealed class GoodsFactory
    {
        private const string GOODS = "GoodsElement";
        private IAssetProvider _assetProvider;
        private DiContainer _container;

        [Inject]
        private void Construct(DiContainer container, IAssetProvider assetProvider)
        {
            _container = container;
            _assetProvider = assetProvider;
        }

        public async Task Prepare() =>
            await _assetProvider.Load<GameObject>(key: GOODS);


        public async Task<GoodsView> Create(Transform parent)
        {
            var prefab = await _assetProvider.Load<GameObject>(key: GOODS);
            return _container.InstantiatePrefabForComponent<GoodsView>(prefab, parent.position, Quaternion.identity, parent);
        }

        public void Clear() =>
            _assetProvider.Release(key: GOODS);
    }
}