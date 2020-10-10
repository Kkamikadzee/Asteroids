using System;
using System.Collections.Generic;
using KMK.Model.Base;
using KMK.Model.Destroyer;
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
            //Обновляется к цикле for, чтобы в процессе обновления коллекция могла меняться.
        {
            lock (_triggers)
            {
                for(int i = 0; i < _triggers.Count; i++)
                {
                    lock (_collision)
                    {
                        for(int j = 0; j < _colliders.Count; j++)
                        {
                            if (_collision.OnCollision(_triggers[i], _colliders[j]))
                            {
                                _triggers[i].OnCollisionEnter(); 
                                _colliders[j].OnCollisionEnter();
                            }
                        }
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