using System;
using System.Collections.Generic;
using KMK.Model.Updater;

namespace KMK.Model.Destroyer
{
    public class UpdatableDestroyer: IDestroyer, IUpdatable
    {
        private List<IDestroyable> _destroyables;
        
        public event Action DisconnectFromObserver;

        public UpdatableDestroyer()
        {
            _destroyables = new List<IDestroyable>();
        }
        
        private bool _containsDestroyable(IDestroyable destroyable)
        {
            return _destroyables.Contains(destroyable);
        }
        
        public void AddDestroyableObject(IDestroyable destroyable)
        {
            if (!_containsDestroyable(destroyable))
            {
                _destroyables.Add(destroyable);
            }
        }

        public void RemoveDestroyableObject(IDestroyable destroyable)
        {
            if (_containsDestroyable(destroyable))
            {
                _destroyables.Remove(destroyable);
            }
        }

        public void Update(float deltaTime)
        {
            if(_destroyables.Count == 0) return;

            lock (_destroyables)
            {
                foreach (var destroyable in _destroyables)
                {
                    destroyable.Destroy();
                }
            
                _destroyables.Clear();
            }
        }
    }
}