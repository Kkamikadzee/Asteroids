using System;
using KMK.Model.Base;

namespace KMK.Model.Updater
{
    public interface IUpdatable
    {
        event Action DisconnectFromObserver;
        
        void Update(float deltaTime);
    }
}