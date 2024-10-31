using System;

namespace Scripts.Configs
{
    [Serializable]
    public struct PriceData
    {
        public float NewPrice;
        public float OldPrice;
        public int Discount => (int)(100 - ((NewPrice * 100) / OldPrice));
    }
}