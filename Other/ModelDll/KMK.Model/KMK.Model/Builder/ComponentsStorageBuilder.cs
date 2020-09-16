using KMK.Model.Base;
using KMK.Model.Collision;
using KMK.Model.Other.Rectangle;

namespace KMK.Model.Builder
{
    public abstract class ComponentsStorageBuilder
    {
        public abstract IComponentsStorage GetIComponentsStorage();
        public virtual void BuildComponentsStorage(Transform transform) { }
        public virtual void BuildSphereCollider(float radius, 
            Vector3 centerPosition, ColliderTag tag, 
            bool isTrigger, bool ifCollisionDestroyer) { }
        public virtual void BuildMover(float velocity, 
            float angularVelocity, bool isRotateObject) { }
        public virtual void BuildMotionController(float maxVelocity, 
            float acceleration, float drag) { }
        public virtual void BuildRotationController(float maxAngularVelocity, 
            float angularAcceleration, float angularDrag) { }
        public virtual void BuildLimitedLifetime(float lifetime) { }
        public virtual void BuildWeapon(float firerate) { }
        public virtual void BuildAutoReloadableWeapon(float firerate,
            float autoAddAmmoTime, int maxAmountAmmo) { }
        public virtual void BuildPursuer(float pursuitRadius, Transform pursued) { }
        public virtual void BuildBouncingInRectangle(Rectangle boundary) { }
        public virtual void BuildMoveInRectangle(Rectangle boundary) { }
        public virtual void BuildScoreGiver(float score) { }
        public virtual void BuildSpawnChildren() { }
    }
}