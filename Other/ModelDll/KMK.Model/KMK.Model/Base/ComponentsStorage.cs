using System;
using System.Collections.Generic;
using System.Linq;
using KMK.Model.Destroyer;

namespace KMK.Model.Base
{
    public class ComponentsStorage : IComponentsStorage, IDestroyable
    {
        private List<Component> _components;
        private Transform _transform;
        
        public event Action<IComponentsStorage> PreparingForDestruction;
        public event Action<IComponentsStorage> Destruction;
        public Transform Transform => _transform;

        public ComponentsStorage()
        {
            _components = new List<Component>();
            _transform = new Transform();
        }

        public ComponentsStorage(Transform transform)
        {
            _components = new List<Component>();
            _transform = transform;
        }
        
        public void AddComponent(Component component)
        {
            _components.Add(component);
        }

        public void RemoveComponent(Component component)
        {
            _components.Remove(component);
        }

        public TComponent GetComponent<TComponent>()
        {
            return _components.OfType<TComponent>().FirstOrDefault();
        }

        public void Destroy()
        {
            foreach (var component in _components)
            {
                component.Destroy();
            }
            
            Destruction?.Invoke(this);

            _components = null;
            _transform = null;
        }

        public void PrepareForDestroy()
        {
            PreparingForDestruction?.Invoke(this);
        }
        public void PrepareForDestroy(Component component)
        {
            PrepareForDestroy();
        }
    }
}