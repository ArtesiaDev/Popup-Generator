using Scripts.Configs;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Scripts.Goods
{
    public class GoodsModel
    {
        public AssetReferenceSprite GoodsIcon { get; private set; }
        public AssetReferenceSprite BackgroundIcon { get; private set; }
        public Color QuantityBackColor { get; private set; }
        public int Quantity { get; private set; }

        public GoodsModel(GoodsData goodsData)
        {
            GoodsIcon = goodsData.GoodsConfig.GoodsIcon;
            BackgroundIcon = goodsData.GoodsConfig.BackgroundIcon;
            QuantityBackColor = goodsData.GoodsConfig.QuantityBackColor;
            Quantity = goodsData.Count;
        }
    }
}