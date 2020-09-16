using System;
using KMK.Model.Base;

namespace KMK.Model.Base
{
    public interface IComponentsStorage : IDestroyable
    {
        event Action<IComponentsStorage> Destruction;

        Transform Transform { get; }

        void AddComponent(Component component);
        void RemoveComponent(Component component);
        TComponent GetComponent<TComponent>();

        void Destroy(Component component);
    }
}