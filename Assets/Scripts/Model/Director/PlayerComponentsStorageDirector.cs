using KMK.Model.Base;
using KMK.Model.Builder;
using KMK.Model.Other.Rectangle;
using Model.Data;
using Vector3 = KMK.Model.Base.Vector3;

namespace Model.Director
{
    public class PlayerComponentsStorageDirector
    {
        private Rectangle _rectangle;

        public PlayerComponentsStorageDirector(Rectangle rectangle)
        {
            _rectangle = rectangle;
        }

        public void Construct(ComponentsStorageBuilder builder, Transform transform, PlayerData data)
        {
            transform.Scale = new Vector3(data.Scale,data.Scale,data.Scale);
            builder.BuildComponentsStorage(transform);
            builder.BuildSphereCollider(data.ColliderRadius, KMK.Model.Base.Vector3.Zero, 
                data.ColliderTag, true, true);
            builder.BuildMover(0, 0 , data.MoverIsRotateObject);
            builder.BuildMotionController(data.MaxVelocity, data.Acceleration, data.Drag);
            builder.BuildRotationController(data.MaxAngularVelocity, data.AngularAcceleration, data.AngularDrag);
            builder.BuildWeapon(data.FireRateFirstWeapon);
            builder.BuildAutoReloadableWeapon(data.FireRateSecondWeapon, data.AutoAddAmmoTimeSecondWeapon,
                data.MaxAmountAmmoSecondWeapon);
            builder.BuildMoveInRectangle(_rectangle);
        }
    }
}