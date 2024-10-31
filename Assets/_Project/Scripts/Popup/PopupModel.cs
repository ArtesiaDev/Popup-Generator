using Scripts.Configs;
using UnityEngine.AddressableAssets;

namespace Scripts.Popup
{
    public class PopupModel
    {
        public string HeaderText { get; private set; }
        public string DescriptionText { get; private set; }
        public AssetReferenceSprite MainImage { get; private set; }
        public PriceData PriceData { get; private set; }

        public PopupModel(string headerText, string descriptionText, AssetReferenceSprite mainSprite, PriceData priceData)
        {
            HeaderText = headerText;
            DescriptionText = descriptionText;
            MainImage = mainSprite;
            PriceData = priceData;
        }
    }
}