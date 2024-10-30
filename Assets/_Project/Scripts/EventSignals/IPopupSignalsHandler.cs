namespace _Project.Scripts.EventSignals
{
    public interface IPopupSignalsHandler
    {
        void OnPopupPurchased(); 
        void OnPopupGenerating();
        void OnPopupClosed();
    }
}