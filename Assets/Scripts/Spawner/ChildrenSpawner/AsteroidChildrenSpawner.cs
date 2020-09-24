using Controller.GameObjectController;
using KMK.Model.Base;
using Model.Data;

namespace Spawner.ChildrenSpawner
{
    public class AsteroidChildrenSpawner: IAsteroidChildrenSpawner
    {
        private IAsteroidsSpawner _spawner;
        private AsteroidsControllers _controllers;
        
        public AsteroidChildrenSpawner(IAsteroidsSpawner spawner, AsteroidsControllers controllers)
        {
            _spawner = spawner;
            _controllers = controllers;
        }


        public void SpawnAsteroidChildren(Transform transform, AsteroidData data)
        {
            var controller = _spawner.SpawnAsteroid(transform, data);
            _controllers.AsteroidControllers.AddController(controller);
        }

        public void SpawnCannonChildren(Transform transform, BulletData data)
        {
            var controller = _spawner.SpawnCannonBullet(transform, data);
            _controllers.CannonBulletControllers.AddController(controller);
        }

        public void SpawnLaserChildren(Transform transform, BulletData data)
        {
            var controller = _spawner.SpawnLaserBullet(transform, data);
            _controllers.LaserControllers.AddController(controller);
        }
    }
}