using System;
using _Project.Scripts.EventSignals;
using _Project.Scripts.Generation;
using Zenject;

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
            _view.SwitchPopupRender(false);
            PopupClosed?.Invoke();
        }

        public void MakePurchase()
        {
            PopupPurchased?.Invoke();
            _view.SwitchPopupRender(false);
        }

        private async void GeneratePopup()
        {
            _model = await _creator.CreatePopup();
            _view = _creator.Popup;
            var mainSprite = await _creator.CreateSprite();
            _view.Draw(_model.HeaderText.ToUpper(), _model.DescriptionText, mainSprite);
        }
    }
}