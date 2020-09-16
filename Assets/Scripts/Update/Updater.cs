using UnityEngine;
using KMK.Model.Updater;

namespace Update
{
    public class Updater: MonoBehaviour, IUpdater
    {
        private UpdaterObservable _movementObservable;
        private UpdaterObservable _collisionObservable;
        private UpdaterObservable _otherFixedUpdateObservable;
        private UpdaterObservable _viewObservable;
        private UpdaterObservable _otherUpdateObservable;

        private bool _active;
        
        public UpdaterObservable MovementObservable => _movementObservable;
        public UpdaterObservable CollisionObservable => _collisionObservable;
        public UpdaterObservable OtherFixedUpdateObservable => _otherFixedUpdateObservable;
        public UpdaterObservable ViewObservable => _viewObservable;
        public UpdaterObservable OtherUpdateObservable => _otherUpdateObservable;

        public bool Active => _active;

        public Updater()
        {
            _movementObservable = new UpdaterObservable();
            _collisionObservable = new UpdaterObservable();
            _otherFixedUpdateObservable = new UpdaterObservable();
            _viewObservable = new UpdaterObservable();
            _otherUpdateObservable = new UpdaterObservable();

            _active = false;
        }

        private void FixedUpdate()
        {
            _collisionObservable.NotifyObservers(Time.fixedTime);
            _movementObservable.NotifyObservers(Time.fixedTime);
            _otherFixedUpdateObservable.NotifyObservers(Time.fixedTime);
        }
        
        private void Update()
        {
            _viewObservable.NotifyObservers(Time.fixedTime);
            _otherUpdateObservable.NotifyObservers(Time.fixedTime);
        }
    }
}