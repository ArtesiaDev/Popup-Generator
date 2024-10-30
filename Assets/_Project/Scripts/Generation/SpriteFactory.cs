using System.Threading.Tasks;
using _Project.Scripts.Services.AssetManagement;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace _Project.Scripts.Generation
{
    public sealed class SpriteFactory
    {
        private IAssetProvider _assetProvider;
        private DiContainer _container;
      
        [Inject]
        private void Construct(DiContainer container, IAssetProvider assetProvider)
        {
            _container = container;
            _assetProvider = assetProvider;
        }
        
        public async Task Prepare(AssetReferenceSprite sprite) =>
            await _assetProvider.LoadAssetReferenceSprite(sprite);

        public async Task<Sprite> Create(AssetReferenceSprite sprite) =>
            await _assetProvider.LoadAssetReferenceSprite(sprite);
        
        public void Clear(AssetReferenceSprite sprite) =>
            _assetProvider.Release(sprite);
    }
}