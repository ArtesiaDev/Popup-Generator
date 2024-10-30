﻿using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "PopupConfig", menuName = "Configs/PopupConfig", order = 0)]
    public class PopupConfig : ScriptableObject
    {
        [field: SerializeField] public string HeaderText { get; private set; }
        [field: SerializeField] public string DescriptionText { get; private set; }
        [field: SerializeField] public AssetReferenceSprite MainImage { get; private set; }
      //  [field: SerializeField] public RewardItem[] RewardItems => rewardItems;
      //  [field: SerializeField] public PriceData PriceData => priceData;
    }
}