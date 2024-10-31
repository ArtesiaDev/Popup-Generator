using System;
using Scripts.EventSignals;
using Scripts.Generation;
using Zenject;
using Object = UnityEngine.Object;

namespace Scripts.Popup
{
    public class PopupController : IInitializable, IDisposable
    {
        public event Action PopupPurchased;
        public event Action PopupClosed;
        public event Action PopupGenerated;

        private IPopupSignals _popupSignals;
        private IPopupSignalsHandler _signalsHandler;
        private PopupCreator _creator;

        private PopupView _view;
        private PopupModel _model;

        [Inject]
        private void Construct(IPopupSignals popupSignals, IPopupSignalsHandler signalsHandler, PopupCreator creator)
        {
            _popupSignals = popupSignals;
            _signalsHandler = signalsHandler;
            _creator = creator;
        }

        public void Initialize()
        {
            PopupPurchased += _signalsHandler.OnPopupPurchased;
            PopupClosed += _signalsHandler.OnPopupClosed;
            PopupGenerated += _signalsHandler.OnPopupGenerated;
            _popupSignals.PopupGenerating += GeneratePopup;
        }

        public void Dispose()
        {
            PopupPurchased -= _signalsHandler.OnPopupPurchased;
            PopupClosed -= _signalsHandler.OnPopupClosed;
            PopupGenerated -= _signalsHandler.OnPopupGenerated;
            _popupSignals.PopupGenerating -= GeneratePopup;
        }

        public void ClosePopup()
        {
            PopupClosed?.Invoke();
            Object.Destroy(_view.gameObject);
            _creator.gameObject.SetActive(false);
        }

        public void MakePurchase()
        {
            PopupPurchased?.Invoke();
            Object.Destroy(_view.gameObject);
            _creator.gameObject.SetActive(false);
        }

        private async void GeneratePopup()
        {
            _creator.gameObject.SetActive(true);
            _model = await _creator.CreatePopup();
            _view = _creator.Popup;
            PopupGenerated?.Invoke();
            var mainSprite = await _creator.CreateSprite(_model.MainImage);
            _view.Draw(_model.HeaderText.ToUpper(), _model.DescriptionText, mainSprite, _model.PriceData);
        }
    }
}