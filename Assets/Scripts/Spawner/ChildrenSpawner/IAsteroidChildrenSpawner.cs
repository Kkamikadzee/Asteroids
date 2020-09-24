using KMK.Model.Base;
using Model.Data;

namespace Spawner.ChildrenSpawner
{
    public interface IAsteroidChildrenSpawner
    {
        void SpawnAsteroidChildren(Transform transform, AsteroidData data);
        void SpawnCannonChildren(Transform transform, BulletData data);
        void SpawnLaserChildren(Transform transform, BulletData data);
    }
}