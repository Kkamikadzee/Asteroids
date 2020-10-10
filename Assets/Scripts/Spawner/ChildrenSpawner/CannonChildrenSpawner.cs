using KMK.Model.Move;
using Model.Data;
using UnityEngine;
using Component = KMK.Model.Base.Component;
using Transform = KMK.Model.Base.Transform;
using Vector3 = KMK.Model.Base.Vector3;

namespace Spawner.ChildrenSpawner
{
    public class CannonChildrenSpawner: ChildrenSpawner
    {
        private GameObjectSpawner _spawner;

        public CannonChildrenSpawner(GameObjectSpawner spawner)
        {
            _spawner = spawner;
        }
        
        public override void SpawnChildren(Component component)
        {
            _spawner.SpawnCannonBullet(new Transform(component.Transform));
        }    
    }
}