using System;
using System.Collections.Generic;
using KMK.Models.Base;
using KMK.Models.Updater;

namespace KMK.Models.Collision
{
    public class CollisionChecker: ICollisionChecker, IUpdatable, IDestroyable
    {
        private List<Collider> _colliders;
        private List<Collider> _triggers;
        private ICollision _collision;

        public event Action<CollisionChecker> Destruction;

        public CollisionChecker(ICollision collision)
        {
            _collision = collision;
            
            _colliders = new List<Collider>();
            _triggers = new List<Collider>();
        }

        public void AddCollider(Collider collider)
        {
            if (_colliders.Contains(collider))
            {
                return;
            }
            _colliders.Add(collider);
            if (collider.IsTrigger)
            {
                _triggers.Add(collider);
            }
        }

        public void RemoveCollider(Collider collider)
        {
            if (!_colliders.Contains(collider))
            {
                return;
            }
            _colliders.Remove(collider);
            if (collider.IsTrigger)
            {
                _triggers.Remove(collider);
            }
        }

        public void Update(float deltaTime)
        {
            foreach (var trigger in _triggers)
            {
                foreach (var collider in _colliders)
                {
                    if (trigger == collider)
                    {
                        continue;
                    }

                    if (_collision.OnCollision(trigger, collider))
                    {
                        trigger.OnCollisionEnter(trigger, collider);
                    }
                }
            }
        }

        public void Destroy()
        {
            _colliders = null;
            _triggers = null;
            _collision = null;
            
            Destruction?.Invoke(this);
        }
    }
}