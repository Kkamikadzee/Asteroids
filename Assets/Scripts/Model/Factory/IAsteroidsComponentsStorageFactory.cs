using KMK.Model.Base;
using Model.Data;

namespace Model.Factory
{
    public interface IAsteroidsComponentsStorageFactory
    {
        IComponentsStorage CreatePlayer(Transform transform, Data.PlayerData data);
        IComponentsStorage CreateAsteroid(Transform transform, AsteroidData data);
        IComponentsStorage CreateUfo(Transform transform, UfoData data);
        IComponentsStorage CreateBullet(Transform transform, BulletData data);
    }
}