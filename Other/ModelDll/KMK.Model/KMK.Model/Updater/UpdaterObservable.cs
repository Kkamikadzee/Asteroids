using System;
using System.Collections.Generic;

namespace KMK.Model.Updater
{
    public class UpdaterObservable: IUpdaterObservable
    {
        private List<IUpdaterObserver> _observers;

        public UpdaterObservable()
        {
            _observers = new List<IUpdaterObserver>();
        }

        private bool _containsObserver(IUpdaterObserver updaterObserver)
        {
            return _observers.Contains(updaterObserver);
        }
        
        public void AddUpdaterObserver(IUpdaterObserver updaterObserver)
        {
            if (!_containsObserver(updaterObserver))
            {
                _observers.Add(updaterObserver);
            }
        }

        public void RemoveUpdaterObserver(IUpdaterObserver updaterObserver)
        {
            if (_containsObserver(updaterObserver))
            {
                _observers.Remove(updaterObserver);
            }
        }

        public void NotifyObservers(float deltaTime)
        {
            foreach (var observer in _observers)
            {
                observer.Update(deltaTime);
            }
        }
    }
}