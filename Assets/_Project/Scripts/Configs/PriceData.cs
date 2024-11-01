using System;
using UnityEngine;

namespace Scripts.Configs
{
    [Serializable]
    public struct PriceData
    {
        public float NewPrice;
        public float OldPrice;
        public int Discount => (int)Mathf.Ceil(100 - (NewPrice * 100 / OldPrice));
    }
}