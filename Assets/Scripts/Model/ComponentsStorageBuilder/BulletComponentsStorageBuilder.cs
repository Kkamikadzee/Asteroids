using KMK.Model.Base;
using KMK.Model.Collision;
using KMK.Model.Move;
using UnityEngine;
using Update;
using SphereCollider = KMK.Model.Collision.SphereCollider;
using Transform = KMK.Model.Base.Transform;
using Vector3 = KMK.Model.Base.Vector3;

namespace Model.ComponentsStorageBuilder
{
    public class BulletComponentsStorageBuilder: KMK.Model.Builder.ComponentsStorageBuilder
    {
        private IUpdater _updater;
        private ICollisionChecker _collisionChecker;

        private IComponentsStorage _componentsStorage;
        
        public BulletComponentsStorageBuilder()
        {
            //TODO: Не забыть конструктор
        }
        
        public override IComponentsStorage GetIComponentsStorage()
        {
            return _componentsStorage;
        }

        public override void BuildComponentsStorage(Transform transform)
        {
            base.BuildComponentsStorage(transform);
            
            _componentsStorage = new ComponentsStorage(transform);
        }

        public override void BuildSphereCollider(float radius, Vector3 centerPosition, ColliderTag tag, bool isTrigger,
            bool ifCollisionDestroyer)
        {
            base.BuildSphereCollider(radius, centerPosition, tag, isTrigger, ifCollisionDestroyer);

            var collider = new SphereCollider(_componentsStorage, tag, radius, centerPosition);
            collider.IsTrigger = true;
            _collisionChecker.AddCollider(collider);
            
            _componentsStorage.AddComponent(collider);

            if (ifCollisionDestroyer)
            {
                collider.Collision += IfCollisionDestroyer.Destroy;
            }
        }

        public override void BuildMover(float velocity, float angularVelocity, bool isRotateObject)
        {
            base.BuildMover(velocity, angularVelocity, isRotateObject);

            var mover = new Mover(_componentsStorage,
                new Vector3(Mathf.Cos(_componentsStorage.Transform.EulerAngles.Z * Mathf.Deg2Rad),
                    Mathf.Sin(_componentsStorage.Transform.EulerAngles.Z * Mathf.Deg2Rad), 0f),
                velocity, angularVelocity, isRotateObject);
            
            _componentsStorage.AddComponent(mover);
            
            _updater.MovementObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
                (mover, _updater.MovementObservable));
        }
    }
}