using KMK.Model.Base;

namespace Spawner.ChildrenSpawner
{
    public abstract class ChildrenSpawner
    {
        public virtual void SpawnChildren(Component component) { }
        public virtual void SpawnChildren(IComponentsStorage componentsStorage) { }
    }
}