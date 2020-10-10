using KMK.Model.Base;
using KMK.Model.Collision;
using KMK.Model.Destroyer;
using KMK.Model.Move;
using KMK.Model.Weapon;
using UnityEngine;
using Update;
using SphereCollider = KMK.Model.Collision.SphereCollider;
using Transform = KMK.Model.Base.Transform;
using Vector3 = KMK.Model.Base.Vector3;

namespace Model.Builder
{
    public class BulletComponentsStorageBuilder: KMK.Model.Builder.ComponentsStorageBuilder
    {
        private IUpdater _updater;
        private IDestroyer _destroyer;
        private ICollisionChecker _collisionChecker;

        private IComponentsStorage _componentsStorage;
        
        public BulletComponentsStorageBuilder(IUpdater updater, IDestroyer destroyer, ICollisionChecker collisionChecker)
        {
            _updater = updater;
            _destroyer = destroyer;
            _collisionChecker = collisionChecker;
        }
        
        public override IComponentsStorage GetIComponentsStorage()
        {
            return _componentsStorage;
        }

        public override void BuildComponentsStorage(Transform transform)
        {
            base.BuildComponentsStorage(transform);
            
            _componentsStorage = new ComponentsStorage(transform);
            
            _componentsStorage.PreparingForDestruction += _destroyer.AddDestroyableObject;
        }

        public override void BuildSphereCollider(float radius, Vector3 centerPosition, ColliderTag tag, bool isTrigger,
            bool ifCollisionDestroyer)
        {
            base.BuildSphereCollider(radius, centerPosition, tag, isTrigger, ifCollisionDestroyer);

            var collider = new SphereCollider(_componentsStorage, tag, radius, centerPosition);
            collider.IsTrigger = isTrigger;
            _collisionChecker.AddCollider(collider);
            
            _componentsStorage.AddComponent(collider);

            if (ifCollisionDestroyer)
            {
                collider.Collision += _componentsStorage.PrepareForDestroy;
            }
        }

        public override void BuildMover(float velocity, float angularVelocity, bool isRotateObject)
        {
            base.BuildMover(velocity, angularVelocity, isRotateObject);

            var mover = new Mover(_componentsStorage, _componentsStorage.Transform.EulerAngles.Z,
                velocity, angularVelocity, isRotateObject);
            
            _componentsStorage.AddComponent(mover);
            
            _updater.MovementObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
                (mover, _updater.MovementObservable));
        }

        public override void BuildLimitedLifetime(float lifetime)
        {
            base.BuildLimitedLifetime(lifetime);

            var component = new LimitedLifetime(_componentsStorage, lifetime);
            
            _componentsStorage.AddComponent(component);
            
            _updater.OtherUpdateObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
                (component, _updater.OtherUpdateObservable));
            
            component.TimeOver += _componentsStorage.PrepareForDestroy;
        }
    }
}