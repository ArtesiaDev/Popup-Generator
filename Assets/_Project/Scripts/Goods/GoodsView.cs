using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Goods
{
    public class GoodsView : MonoBehaviour
    {
        [SerializeField] private Image _goodsIcon;
        [SerializeField] private Image _backgroundIcon;
        [SerializeField] private TextMeshProUGUI _quantity;
        [SerializeField] private Image _backgroundQuantity;

        public void Draw(Sprite goodsIcon, Sprite backgroundIcon, int quantity, Color quantityBackColor)
        {
            _goodsIcon.sprite = goodsIcon;
            _backgroundIcon.sprite = backgroundIcon;
            _quantity.text = $"{quantity}";
            _backgroundQuantity.color = quantityBackColor;
        }
    }
}