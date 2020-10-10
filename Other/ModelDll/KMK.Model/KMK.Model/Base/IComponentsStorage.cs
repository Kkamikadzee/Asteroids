using System;
using KMK.Model.Base;
using KMK.Model.Destroyer;

namespace KMK.Model.Base
{
    public interface IComponentsStorage : IDestroyable
    {
        event Action<IComponentsStorage> PreparingForDestruction;
        event Action<IComponentsStorage> Destruction;
        
        Transform Transform { get; }

        void AddComponent(Component component);
        void RemoveComponent(Component component);
        TComponent GetComponent<TComponent>();
        
        void PrepareForDestroy();
        void PrepareForDestroy(Component component);
    }
}