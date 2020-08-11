using System;
using KMK.Models.Base;

namespace KMK.Models.Collision
{
    public abstract class Collider: Component
    {
        private ColliderTag _tag;
        private bool _isTrigger;

        public event Action<Collider> Destruction;
        public event Action<Collider, Collider> Collision;

        public ColliderTag Tag => _tag;

        public bool IsTrigger
        {
            get => _isTrigger;
            set => _isTrigger = value;
        }

        protected Collider(IComponentsStorage parent, ColliderTag tag) : base(parent)
        {
            _tag = tag;
        }

        public void OnCollisionEnter(Collider trigger, Collider collider)
        {
            Collision?.Invoke(trigger, collider);
        }
        
        public override void Destroy()
        {
            base.Destroy();

            Destruction?.Invoke(this);
        }
    }
}