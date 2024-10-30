using System;
using _Project.Scripts.EventSignals;
using _Project.Scripts.Generation;
using Zenject;
using Object = UnityEngine.Object;

namespace _Project.Scripts.Popup
{
    public class PopupController : IInitializable, IDisposable
    {
        public event Action PopupPurchased;
        public event Action PopupClosed;

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
            _popupSignals.PopupGenerating += GeneratePopup;
        }

        public void Dispose()
        {
            PopupPurchased -= _signalsHandler.OnPopupPurchased;
            PopupClosed -= _signalsHandler.OnPopupClosed;
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
            var mainSprite = await _creator.CreateSprite();
            _view.Draw(_model.HeaderText.ToUpper(), _model.DescriptionText, mainSprite, _model.PriceData);
        }
    }
}