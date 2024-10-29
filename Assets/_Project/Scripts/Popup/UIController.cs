using System;
using _Project.Scripts.EventSignals;
using Zenject;

namespace _Project.Scripts.Popup
{
    public class UIController: IInitializable, IDisposable
    {
        private IPopupSignals _popupSignals;
        private UIView _view;

        [Inject]
        private void Construct(IPopupSignals popupSignals , UIView view)
        {
            _popupSignals = popupSignals;
            _view = view;
        }

        public void Initialize() => 
            _popupSignals.PopupPurchased += EnablePurchasePanel;

        public void Dispose() => 
            _popupSignals.PopupPurchased -= EnablePurchasePanel;

        public void GeneratePopup()
        {
            _view.LockingGenerateButton(false);
        }

        public void ClosePurchaseMessage()
        {
            _view.SwitchPurchaseMessageRendering(false);
            _view.LockingGenerateButton(true);
        }

        private void EnablePurchasePanel() =>
            _view.SwitchPurchaseMessageRendering(true);
    }
}