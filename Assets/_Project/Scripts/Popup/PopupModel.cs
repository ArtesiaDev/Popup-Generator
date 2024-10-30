using UnityEngine.AddressableAssets;

namespace _Project.Scripts.Popup
{
    public class PopupModel
    {
        public string HeaderText { get; private set; }
        public string DescriptionText { get; private set; }
        public AssetReferenceSprite MainImage { get; private set; }
        //  [field: SerializeField] public RewardItem[] RewardItems => rewardItems;
        //  [field: SerializeField] public PriceData PriceData => priceData;

        public PopupModel(string headerText, string descriptionText, AssetReferenceSprite mainSprite)
        {
            HeaderText = headerText;
            DescriptionText = descriptionText;
            MainImage = mainSprite;
        }
    }
}