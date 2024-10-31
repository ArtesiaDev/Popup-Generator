using System;

namespace Scripts.EventSignals
{
    public interface IPopupSignals
    {
        event Action PopupPurchased;
        event Action PopupGenerating;
        event Action PopupGenerated;
        event Action PopupClosed;
    }
}