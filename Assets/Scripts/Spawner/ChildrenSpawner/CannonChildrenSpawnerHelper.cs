using KMK.Model.Move;
using Model.Data;
using UnityEngine;
using Component = KMK.Model.Base.Component;
using Transform = KMK.Model.Base.Transform;
using Vector3 = KMK.Model.Base.Vector3;

namespace Spawner.ChildrenSpawner
{
    public class CannonChildrenSpawnerHelper: ChildrenSpawnerHelper
    {
        private IAsteroidChildrenSpawner _spawner;
        private AsteroidsDataStorage _dataStorage;

        public CannonChildrenSpawnerHelper(IAsteroidChildrenSpawner spawner, AsteroidsDataStorage dataStorage)
        {
            _spawner = spawner;
            _dataStorage = dataStorage;
        }
        
        public override void SpawnChildren(Component component)
        {
            var data = _dataStorage.CannonBullet;
            
            if ((data != null))
            {
                _spawner.SpawnCannonChildren(new Transform(component.Transform), data);
            }
        }    
    }
}