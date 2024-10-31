using System.Threading.Tasks;
using Scripts.Services.AssetManagement;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Scripts.Generation
{
    public sealed class SpriteFactory
    {
        private IAssetProvider _assetProvider;
      
        [Inject]
        private void Construct(DiContainer container, IAssetProvider assetProvider) =>
            _assetProvider = assetProvider;

        public async Task Prepare(AssetReferenceSprite sprite) =>
            await _assetProvider.LoadAssetReferenceSprite(sprite);

        public async Task<Sprite> Create(AssetReferenceSprite sprite) =>
            await _assetProvider.LoadAssetReferenceSprite(sprite);
        
        public void Clear(AssetReferenceSprite sprite) =>
            _assetProvider.Release(sprite);
    }
}