using System;
using KMK.Model.Base;

namespace KMK.Model.Collision
{
    public abstract class Collider: Component
    {
        private ColliderTag _tag;
        private bool _isTrigger;

        public event Action<Collider> Destruction;
        public event Action<Collider> Collision;

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

        public void OnCollisionEnter()
        {
            Collision?.Invoke(this);
        }
        
        public override void Destroy()
        {
            base.Destroy();

            Destruction?.Invoke(this);
        }
    }
}