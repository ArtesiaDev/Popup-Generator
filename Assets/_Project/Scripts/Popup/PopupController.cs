using System;
using _Project.Scripts.EventSignals;
using Zenject;

namespace _Project.Scripts.Popup
{
    public class PopupController: IInitializable, IDisposable
    {
        public event Action PopupPurchased;

        private IPopupSignalsHandler _signalsHandler;
        private PopupModel _model;
        private PopupView _view;

        [Inject]
        private void Construct(IPopupSignalsHandler signalsHandler ,PopupModel model, PopupView view)
        {
            _signalsHandler = signalsHandler;
            _model = model;
            _view = view;
        }

        public void Initialize() =>
            PopupPurchased += _signalsHandler.OnPopupPurchased;

        public void Dispose() =>
            PopupPurchased -= _signalsHandler.OnPopupPurchased;

        public void ClosePopup() =>
            _view.SwitchPopupRender(false);

        public void MakePurchase()
        {
            PopupPurchased?.Invoke();
            _view.SwitchPopupRender(false);
        }
    }
}