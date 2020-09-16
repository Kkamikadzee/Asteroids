using System;
using KMK.Model.Base;
using KMK.Model.Updater;

namespace KMK.Model.Weapon
{
    public class LimitedLifetime: Component, IUpdatable
    {
        private float _lifetime;
        private float _currentLifetime;
        
        public event Action<LimitedLifetime> Destruction;
        public event Action DisconnectFromObserver;

        public LimitedLifetime(IComponentsStorage parent, float lifetime) : base(parent)
        {
            _lifetime = lifetime;
        }

        public void Update(float deltaTime)
        {
            _currentLifetime += deltaTime;
        }
        
        public override void Destroy()
        {
            base.Destroy();
            DisconnectFromObserver?.Invoke();
            Destruction?.Invoke(this);
        }
    }
}