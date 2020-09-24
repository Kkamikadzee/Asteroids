using System;
using System.Collections.Generic;
using KMK.Model.Base;
using KMK.Model.Updater;

namespace KMK.Model.Collision
{
    public class CollisionChecker: ICollisionChecker, IUpdatable, IDestroyable
    {
        private List<Collider> _colliders;
        private List<Collider> _triggers;
        private ICollision _collision;

        public event Action<CollisionChecker> Destruction;
        public event Action DisconnectFromObserver;

        public CollisionChecker(ICollision collision)
        {
            _collision = collision;
            
            _colliders = new List<Collider>();
            _triggers = new List<Collider>();
        }

        public void AddCollider(Collider collider)
        {
            if (collider.IsTrigger)
            {
                if (!_triggers.Contains(collider))
                {
                    _triggers.Add(collider);
                    collider.Destruction += RemoveCollider;
                }
            }
            else
            {
                if (!_colliders.Contains(collider))
                {
                    _colliders.Add(collider);
                    collider.Destruction += RemoveCollider;
                }
            }
        }

        public void RemoveCollider(Collider collider)
        {
            if (collider.IsTrigger)
            {
                if (_triggers.Contains(collider))
                {
                    _triggers.Remove(collider);
                }
            }
            else
            {
                if (_colliders.Contains(collider))
                {
                    _colliders.Remove(collider);
                }
            }
        }

        public void Update(float deltaTime)
        {
            foreach (var trigger in _triggers)
            {
                foreach (var collider in _colliders)
                {
                    if (_collision.OnCollision(trigger, collider))
                    {
                        trigger.OnCollisionEnter(); 
                        collider.OnCollisionEnter();
                    }
                }
            }
        }

        public void Destroy()
        {
            _colliders = null;
            _triggers = null;
            _collision = null;
            
            DisconnectFromObserver?.Invoke();
            Destruction?.Invoke(this);
        }
    }
}