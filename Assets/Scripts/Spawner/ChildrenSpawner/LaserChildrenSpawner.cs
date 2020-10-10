using KMK.Model.Base;
using Model.Data;

namespace Spawner.ChildrenSpawner
{
    public class LaserChildrenSpawner: ChildrenSpawner
    {
        private GameObjectSpawner _spawner;

        public LaserChildrenSpawner(GameObjectSpawner spawner)
        {
            _spawner = spawner;
        }
        
        public override void SpawnChildren(Component component)
        {
            _spawner.SpawnLaserBullet(new Transform(component.Transform));
        }    
    }
}