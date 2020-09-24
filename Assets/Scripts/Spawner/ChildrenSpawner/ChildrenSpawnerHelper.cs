using KMK.Model.Base;

namespace Spawner.ChildrenSpawner
{
    public abstract class ChildrenSpawnerHelper
    {
        public virtual void SpawnChildren(Component component) { }
        public virtual void SpawnChildren(IComponentsStorage componentsStorage) { }
    }
}