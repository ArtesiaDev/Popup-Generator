using System;

namespace _Project.Scripts.EventSignals
{
    public interface IPopupSignals
    {
        event Action PopupPurchased;
        event Action PopupGenerating;
        event Action PopupClosed;
    }
}