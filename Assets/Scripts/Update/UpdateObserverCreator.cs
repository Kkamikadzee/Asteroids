using KMK.Model.Updater;
using View.GameObjectView;

namespace Update
{
    public static class UpdateObserverCreator
    {
        public static UpdaterObserver GetObserver(IUpdatable updatable, IUpdaterObservable observable)
        {
            var observer = new UpdaterObserver(updatable, observable);

            updatable.DisconnectFromObserver += observer.DisconnectToUpdater;

            return observer;
        }
    }
}