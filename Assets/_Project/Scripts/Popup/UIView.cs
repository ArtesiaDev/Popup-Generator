using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Scripts.Popup
{
    public class UIView : MonoBehaviour
    {
        [SerializeField] private Button _generateButton;
        [SerializeField] private Button _purchaseMessage;

        private UIController _controller;

        [Inject]
        private void Construct(UIController controller) =>
            _controller = controller;

        private void OnEnable()
        {
            _generateButton.onClick.AddListener(_controller.GeneratePopup);
            _purchaseMessage.onClick.AddListener(_controller.ClosePurchaseMessage);
        }

        private void OnDisable() =>
            _generateButton.onClick.RemoveAllListeners();


        public void SwitchPurchaseMessageRendering(bool condition) =>
            _purchaseMessage.gameObject.SetActive(condition);

        public void LockingGenerateButton(bool condition) =>
            _generateButton.interactable = condition;
    }
}