using KMK.Model.Base;
using Model.Data;

namespace Spawner.ChildrenSpawner
{
    public class LaserChildrenSpawnerHelper: ChildrenSpawnerHelper
    {
        private IAsteroidChildrenSpawner _spawner;
        private AsteroidsDataStorage _dataStorage;

        public LaserChildrenSpawnerHelper(IAsteroidChildrenSpawner spawner, AsteroidsDataStorage dataStorage)
        {
            _spawner = spawner;
            _dataStorage = dataStorage;
        }
        
        public override void SpawnChildren(Component component)
        {
            var data = _dataStorage.LaserBullet;

            if ((data != null))
            {
                _spawner.SpawnLaserChildren(new Transform(component.Transform), data);
            }
        }    
    }
}