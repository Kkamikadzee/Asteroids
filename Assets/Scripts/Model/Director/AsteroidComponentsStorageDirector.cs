using KMK.Model.Base;
using KMK.Model.Builder;
using KMK.Model.Other.Rectangle;

namespace Model.Director
{
    public class AsteroidComponentsStorageDirector
    {
        private Rectangle _rectangle;

        public AsteroidComponentsStorageDirector(Rectangle rectangle)
        {
            _rectangle = rectangle;
        }

        public void Construct(ComponentsStorageBuilder builder, Transform transform, Data.AsteroidData data)
        {
            transform.Scale = new Vector3(data.Scale,data.Scale,data.Scale);
            builder.BuildComponentsStorage(transform);
            builder.BuildSphereCollider(data.ColliderRadius, KMK.Model.Base.Vector3.Zero, 
                data.ColliderTag, false, true);
            builder.BuildMover(data.Velocity, 0 , data.MoverIsRotateObject);
            builder.BuildBouncingInRectangle(_rectangle);
            builder.BuildScoreGiver(data.GivenScore);
            builder.BuildSpawnChildren();
        }
    }
}