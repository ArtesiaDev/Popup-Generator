using System;
using UnityEngine;

namespace Scripts.Configs
{
    [Serializable]
    public struct GoodsData
    {
        [field: SerializeField] public GoodsConfig GoodsConfig { get; private set; }
        [field: SerializeField] public int Count { get; private set; }
    }
}