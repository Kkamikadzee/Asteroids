using System;
using KMK.Model.Updater;
using UnityEngine;

namespace View.UI
{
    public abstract class UiElement: IUpdatable
    {
        protected Vector3 _position;

        public abstract event Action DisconnectFromObserver;
        
        public abstract event Action Refresh;

        protected UiElement(Vector3 position)
        {
            _position = position;
        }

        public abstract void Update(float deltaTime);

        public abstract void Destroy();
    }
}