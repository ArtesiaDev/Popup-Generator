using _Project.Scripts.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.Popup
{
    public class PopupView : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _buyButton;
        [SerializeField] private TextMeshProUGUI _header;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private TextMeshProUGUI _newPrice;
        [SerializeField] private TextMeshProUGUI _oldPrice;
        [SerializeField] private TextMeshProUGUI _discount;
        [SerializeField] private Image _mainImage;

        private PopupController _controller;

        [Inject]
        private void Construct(PopupController controller)
        {
            _controller = controller;
        }

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(_controller.ClosePopup);
            _buyButton.onClick.AddListener(_controller.MakePurchase);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveAllListeners();
            _buyButton.onClick.RemoveAllListeners();
        }

        public void Draw(string header, string description, Sprite mainSprite, PriceData priceData)
        {
            _header.text = header;
            _description.text = description;
            _mainImage.sprite = mainSprite;
            _newPrice.text = $"${priceData.NewPrice}"; 
            _oldPrice.text = $"<s>$ {priceData.OldPrice}</s>";
            _discount.text = $"{priceData.Discount}%";
        }
    }
}