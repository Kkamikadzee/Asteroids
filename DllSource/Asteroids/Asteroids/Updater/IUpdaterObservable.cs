namespace KMK.Models.Updater
{
    public interface IUpdaterObservable
    {
        void AddUpdaterObserver(IUpdaterObserver updaterObserver);
        void RemoveUpdaterObserver(IUpdaterObserver updaterObserver);
        void NotifyObservers(float deltaTime);
    }
}