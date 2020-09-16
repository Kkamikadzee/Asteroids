using Controller.GameObjectController;
using KMK.Model.Base;
using Model.Data;

namespace Spawner
{
    public interface IAsteroidsSpawner
    {
        GameObjectController SpawnPlayer(Transform transform, Model.Data.PlayerData playerData);
        GameObjectController SpawnAsteroid(Transform transform, AsteroidData asteroidData);
        GameObjectController SpawnUfo(Transform transform, UfoData ufoData);
        GameObjectController SpawnCannonBullet(Transform transform, BulletData bulletData);
        GameObjectController SpawnLaserBullet(Transform transform, BulletData bulletData);
    }
}