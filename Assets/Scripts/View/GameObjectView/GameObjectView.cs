using System;
using KMK.Model.Base;
using KMK.Model.Destroyer;
using KMK.Model.Updater;
using UnityEngine;
using Object = UnityEngine.Object;

namespace View.GameObjectView
{
    public abstract class GameObjectView: IUpdatable, IDestroyable
    {
        protected GameObject _gameObject;

        public abstract event Action<GameObjectView> Refresh;
        
        public event Action DisconnectFromObserver;
        
        protected GameObjectView(GameObject gameObject)
        {
            _gameObject = gameObject;
        }

        public abstract void Update(float deltaTime);

        public void Destroy()
        {
            DisconnectFromObserver?.Invoke();
            
            Object.Destroy(_gameObject);
        }
    }
}