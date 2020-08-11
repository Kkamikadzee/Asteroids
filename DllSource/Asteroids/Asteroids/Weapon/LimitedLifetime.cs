using System;
using KMK.Models.Base;
using KMK.Models.Updater;

namespace KMK.Models.Weapon
{
    public class LimitedLifetime: Component, IUpdatable
    {
        private float _lifetime;
        private float _currentLifetime;
        
        public event Action<LimitedLifetime> Destruction;
        
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

            Destruction?.Invoke(this);
        }
    }
}