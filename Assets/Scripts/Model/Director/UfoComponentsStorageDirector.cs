using Controller.Game;
using KMK.Model.Base;
using KMK.Model.Builder;
using KMK.Model.Other.Rectangle;

namespace Model.Director
{
    public class UfoComponentsStorageDirector
    {
        private Rectangle _rectangle;
        private GetterPlayerTransform _playerTransform;

        public UfoComponentsStorageDirector(Rectangle rectangle, GetterPlayerTransform playerTransform)
        {
            _rectangle = rectangle;
            _playerTransform = playerTransform;
        }

        public void Construct(ComponentsStorageBuilder builder, Transform transform, Data.UfoData data)
        {
            transform.Scale = new Vector3(data.Scale,data.Scale,data.Scale);
            builder.BuildComponentsStorage(transform);
            builder.BuildSphereCollider(data.ColliderRadius, KMK.Model.Base.Vector3.Zero,
                data.ColliderTag, false, true);
            builder.BuildMover(0, 0, data.MoverIsRotateObject);
            builder.BuildMotionController(data.MaxVelocity, data.Acceleration, data.Drag);
            builder.BuildMoveInRectangle(_rectangle);
            builder.BuildPursuer(data.PursuitRadius, _playerTransform.PlayerTransform);
            builder.BuildScoreGiver(data.GivenScore);
        }
    }
}