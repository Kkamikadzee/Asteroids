using System;
using KMK.Model.Destroyer;
using KMK.Model.Updater;
using UnityEngine;

namespace View.UI
{
    public abstract class UiElement: IUpdatable, IDestroyable
    {
        public abstract event Action DisconnectFromObserver;
        
        public abstract event Action Refresh;

        protected UiElement(Vector3 position) { }

        public abstract void Update(float deltaTime);

        public abstract void Destroy();
    }
}