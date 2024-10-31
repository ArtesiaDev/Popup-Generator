using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Scripts.Configs
{
    [CreateAssetMenu(fileName = "PopupConfig", menuName = "Configs/PopupConfig", order = 0)]
    public class PopupConfig : ScriptableObject
    {
        [field: SerializeField] public string HeaderText { get; private set; }
        [field: SerializeField] public string DescriptionText { get; private set; }
        [field: SerializeField] public AssetReferenceSprite MainImage { get; private set; }
        [field: SerializeField] public PriceData PriceData { get; private set; }
        [field: SerializeField] public GoodsData[] GoodsData { get; private set; }
    }
}