using System;
using KMK.Models.Base;

namespace KMK.Models.Base
{
    public interface IComponentsStorage : IDestroyable
    {
        event Action<IComponentsStorage> Destruction;

        Transform Transform { get; }

        void AddComponent(Component component);
        void RemoveComponent(Component component);
        TComponent GetComponent<TComponent>() where TComponent : Component;

        void Destroy(Component component);
    }
}