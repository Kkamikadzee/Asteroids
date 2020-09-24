using KMK.Model.Base;
using KMK.Model.Collision;
using KMK.Model.Move;
using KMK.Model.Other.Bounce;
using KMK.Model.Other.Rectangle;
using KMK.Model.Scorer;
using Spawner.ChildrenSpawner;
using UnityEngine;
using Update;
using SphereCollider = KMK.Model.Collision.SphereCollider;
using Transform = KMK.Model.Base.Transform;
using Vector3 = KMK.Model.Base.Vector3;

namespace Model.Builder
{
    public class AsteroidComponentsStorageBuilder: KMK.Model.Builder.ComponentsStorageBuilder
    {
        private IUpdater _updater;
        private ICollisionChecker _collisionChecker;
        private ChildrenSpawnerHelper _childrenSpawner;
        private IScorer _score;

        private IComponentsStorage _componentsStorage;
        private Mover _mover;
        
        public AsteroidComponentsStorageBuilder(IUpdater updater, ICollisionChecker collisionChecker,
            ChildrenSpawnerHelper childrenSpawner, IScorer score)
        {
            _updater = updater;
            _collisionChecker = collisionChecker;
            _childrenSpawner = childrenSpawner;
            _score = score;
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
            collider.IsTrigger = isTrigger;
            _collisionChecker.AddCollider(collider);
            
            _componentsStorage.AddComponent(collider);

            if (ifCollisionDestroyer)
            {
                collider.Collision += _componentsStorage.Destroy;
            }
        }

        public override void BuildMover(float velocity, float angularVelocity, bool isRotateObject)
        {
            base.BuildMover(velocity, angularVelocity, isRotateObject);

            _mover = new Mover(_componentsStorage, _componentsStorage.Transform.EulerAngles.Z,
                velocity, angularVelocity, isRotateObject);
            
            _componentsStorage.AddComponent(_mover);
            
            _updater.MovementObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
                (_mover, _updater.MovementObservable));
        }

        public override void BuildBouncingInRectangle(Rectangle boundary)
        {
            base.BuildBouncingInRectangle(boundary);
            
            var component = new BouncingComponent(_componentsStorage, _mover);
            var bouncingInRectangle = new BouncingInRectangle(_componentsStorage, boundary, component);
            
            _componentsStorage.AddComponent(component);
            _componentsStorage.AddComponent(bouncingInRectangle);
            
            _updater.MovementObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
                (bouncingInRectangle, _updater.MovementObservable));
        }

        public override void BuildSpawnChildren()
        {
            base.BuildSpawnChildren();

            _componentsStorage.Destruction += _childrenSpawner.SpawnChildren;
        }
        
        public override void BuildScoreGiver(float score)
        {
            base.BuildScoreGiver(score);
            
            var giver = new ScoreGiver(_componentsStorage, score);
            
            _componentsStorage.AddComponent(giver);

            giver.Give += _score.AddScore;
        }
    }
}