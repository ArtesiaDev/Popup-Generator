using System;
using Scripts.EventSignals;
using Zenject;

namespace Scripts.Popup
{
    public class UIController: IInitializable, IDisposable
    {
        public event Action PopupGenerating;
        
        private IPopupSignals _popupSignals;
        private IPopupSignalsHandler _popupSignalsHandler;
        private UIView _view;

        [Inject]
        private void Construct(IPopupSignals popupSignals ,IPopupSignalsHandler popupSignalsHandler, UIView view)
        {
            _popupSignals = popupSignals;
            _popupSignalsHandler = popupSignalsHandler;
            _view = view;
        }

        public void Initialize()
        {
            _popupSignals.PopupPurchased += EnablePurchasePanel;
            _popupSignals.PopupClosed += UnlockButtonAfterClosing;
            PopupGenerating += _popupSignalsHandler.OnPopupGenerating;
        }

        public void Dispose()
        {
            _popupSignals.PopupPurchased -= EnablePurchasePanel;
            _popupSignals.PopupClosed -= UnlockButtonAfterClosing;
            PopupGenerating -= _popupSignalsHandler.OnPopupGenerating;
        }

        public void GeneratePopup()
        {
            _view.LockingGenerateButton(false);
            PopupGenerating?.Invoke();
        }

        public void ClosePurchaseMessage()
        {
            _view.SwitchPurchaseMessageRendering(false);
            _view.LockingGenerateButton(true);
        }

        private void EnablePurchasePanel() =>
            _view.SwitchPurchaseMessageRendering(true);

        private void UnlockButtonAfterClosing() =>
            _view.LockingGenerateButton(true);
    }
}