using System;

namespace _Project.Scripts.EventSignals
{
    public class PopupSignals : IPopupSignals, IPopupSignalsHandler
    {
        public event Action PopupPurchased;
        public event Action PopupGenerating;

        public event Action PopupClosed;

        public void OnPopupPurchased() =>
            PopupPurchased?.Invoke();

        public void OnPopupGenerating() =>
            PopupGenerating?.Invoke();

        public void OnPopupClosed() =>
            PopupClosed?.Invoke();
    }
}