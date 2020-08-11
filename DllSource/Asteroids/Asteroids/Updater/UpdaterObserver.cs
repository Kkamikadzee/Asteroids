﻿namespace KMK.Models.Updater
{
    public class UpdaterObserver : IUpdaterObserver
    {
        private IUpdatable _updatableObject;
        private IUpdaterObservable _updater;

        public UpdaterObserver(IUpdatable updatableObject, IUpdaterObservable updater)
        {
            _updatableObject = updatableObject;
            _updater = updater;
        }
        
        public void ConnectToUpdater()
        {
            _updater.AddUpdaterObserver(this);
        }
        
        public void DisconnectToUpdater()
        {
            _updater.RemoveUpdaterObserver(this);
        }

        public void Update(float deltaTime)
        {
            _updatableObject.Update(deltaTime);
        }
    }
}