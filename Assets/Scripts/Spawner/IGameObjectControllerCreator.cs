using Controller.GameObjectController;
using KMK.Model.Base;
using Model.Data;

namespace Spawner
{
    public interface IGameObjectControllerCreator
    {
        GameObjectController CreatePlayer(Transform transform, Model.Data.PlayerData playerData);
        GameObjectController CreateAsteroid(Transform transform, AsteroidData asteroidData);
        GameObjectController CreateUfo(Transform transform, UfoData ufoData);
        GameObjectController CreateCannonBullet(Transform transform, BulletData bulletData);
        GameObjectController CreateLaserBullet(Transform transform, BulletData bulletData);
    }
}