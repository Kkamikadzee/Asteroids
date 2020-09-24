using KMK.Model.Base;
using KMK.Model.Builder;

namespace Model.Director
{
    public class BulletComponentsStorageDirector
    {
        public BulletComponentsStorageDirector() { }

        public void Construct(ComponentsStorageBuilder builder, Transform transform, Data.BulletData data)
        {
            transform.Scale = new Vector3(data.Scale,data.Scale,data.Scale);
            builder.BuildComponentsStorage(transform);
            builder.BuildSphereCollider(data.ColliderRadius, KMK.Model.Base.Vector3.Zero, 
                data.ColliderTag, true, data.DestroyIfHit);
            builder.BuildMover(data.Velocity, 0 , data.MoverIsRotateObject);
            builder.BuildLimitedLifetime(data.Lifetime);
        }
    }
}