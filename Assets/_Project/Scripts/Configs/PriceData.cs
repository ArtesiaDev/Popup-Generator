using System;
using UnityEngine;

namespace Scripts.Configs
{
    [Serializable]
    public struct PriceData
    {
        [field: SerializeField] public float NewPrice { get; private set; }
        [field: SerializeField] public float OldPrice { get; private set; }
        public int Discount => (int)Mathf.Ceil(100 - (NewPrice * 100 / OldPrice));
    }
}