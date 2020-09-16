using KMK.Model.Updater;

namespace Update
{
    public interface IUpdater
    {
        UpdaterObservable MovementObservable { get; }
        UpdaterObservable CollisionObservable { get; }
        UpdaterObservable OtherFixedUpdateObservable  { get; }
        UpdaterObservable ViewObservable  { get; }
        UpdaterObservable OtherUpdateObservable { get; }

    }
}