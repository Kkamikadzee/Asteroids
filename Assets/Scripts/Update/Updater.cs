using UnityEngine;

namespace Update
{
    public class Updater : MonoBehaviour
    {
        private UpdaterObservable _movementObservable;
        private UpdaterObservable _collisionObservable;
        private UpdaterObservable _otherObservable;
        
        private UpdaterObservable MovementObservable => _movementObservable;
        private UpdaterObservable CollisionObservable => _collisionObservable;
        private UpdaterObservable OtherObservable => _otherObservable;

        public Updater()
        {
            _movementObservable = new UpdaterObservable(); //TODO: Использовать для этого фабрику и место объектов класса - интерфейсы
            _collisionObservable = new UpdaterObservable();
            _otherObservable = new UpdaterObservable();
        }

        private void FixedUpdate()
        {
            _collisionObservable.NotifyObservers(Time.fixedTime);
            _movementObservable.NotifyObservers(Time.fixedTime);
            _otherObservable.NotifyObservers(Time.fixedTime);
        }
    }
}