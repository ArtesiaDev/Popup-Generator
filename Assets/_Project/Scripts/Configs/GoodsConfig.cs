using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Scripts.Configs
{
    [CreateAssetMenu(fileName = "GoodsConfig", menuName = "Configs/GoodsConfig", order = 1)]
    public class GoodsConfig : ScriptableObject
    {
        [field: SerializeField] public AssetReferenceSprite GoodsIcon { get; private set; }
        [field: SerializeField] public AssetReferenceSprite BackgroundIcon { get; private set; }
        [field: SerializeField] public Color QuantityBackColor { get; private set; }
    }
}