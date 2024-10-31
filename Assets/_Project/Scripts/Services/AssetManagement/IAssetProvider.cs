using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Scripts.Services.AssetManagement
{
    public interface IAssetProvider
    {
        public Task<T> Load<T>(string key) where T : class;
        public Task<Sprite> LoadAssetReferenceSprite(AssetReferenceSprite sprite);
        public void Release(string key);
        public void Release(AssetReferenceSprite sprite);
    }
}