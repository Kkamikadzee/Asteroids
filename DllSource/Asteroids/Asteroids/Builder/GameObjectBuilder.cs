using KMK.Models.Base;

namespace KMK.Models.Builder
{
    public abstract class GameObjectBuilder
    {
        public virtual void BuildComponentsStorage() { }
        public virtual void BuildComponentsStorage(Transform transform) { }
        public virtual void BuildSphereCollider() { }
        public virtual void BuildMover() { }
        public virtual void BuildMotionController() { }
        public virtual void BuildRotationController() { }
        public virtual void BuildLimitedLifetime() { }
        public virtual void BuildWeapon() { }
        public virtual void BuildAutoReloadableWeapon() { }
        public virtual void BuildPursuer() { }
        public virtual void BuildBouncingInRectangle() { }
        public virtual void BuildMoveInRectangle() { }
    }
}