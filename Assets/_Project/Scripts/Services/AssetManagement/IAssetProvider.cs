using System.Threading.Tasks;

namespace _Project.Scripts.Services.AssetManagement
{
    public interface IAssetProvider
    {
        public Task<T> Load<T>(string key) where T : class;
        public void Release(string key);
    }
}