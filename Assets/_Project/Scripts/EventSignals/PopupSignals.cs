using System;

namespace _Project.Scripts.EventSignals
{
    public class PopupSignals : IPopupSignals, IPopupSignalsHandler
    {
        public event Action PopupPurchased;

        public void OnPopupPurchased() =>
            PopupPurchased?.Invoke();
    }
}