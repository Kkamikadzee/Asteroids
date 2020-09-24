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
            if (_active)
            {
                _movementObservable.NotifyObservers(Time.fixedDeltaTime);
                _otherFixedUpdateObservable.NotifyObservers(Time.fixedDeltaTime);
            }
        }
        
        private void Update()
        {
            if (_active)
            {
                _collisionObservable.NotifyObservers(Time.fixedDeltaTime);
                _viewObservable.NotifyObservers(Time.deltaTime);
                _otherUpdateObservable.NotifyObservers(Time.deltaTime);
            }
        }

        public void Enable()
        {
            _active = true;
        }

        public void Disable()
        {
            _active = false;
        }
    }
}