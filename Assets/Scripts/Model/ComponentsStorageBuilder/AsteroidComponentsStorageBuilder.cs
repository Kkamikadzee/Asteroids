using Controller.UI;
using KMK.Model.Adapter;
using KMK.Model.Base;
using KMK.Model.Collision;
using KMK.Model.Move;
using KMK.Model.Other.Rectangle;
using KMK.Model.Scorer;
using KMK.Model.Weapon;
using Spawner.ChildrenSpawner;
using UnityEngine;
using Update;
using SphereCollider = KMK.Model.Collision.SphereCollider;
using Transform = KMK.Model.Base.Transform;
using Vector3 = KMK.Model.Base.Vector3;

namespace Model.ComponentsStorageBuilder
{
    public class AsteroidComponentsStorageBuilder: KMK.Model.Builder.ComponentsStorageBuilder
    {
        private IUpdater _updater;
        private ICollisionChecker _collisionChecker;
        private IChildrenSpawnerHelper _childrenSpawner;
        private IScorer _score;

        private IComponentsStorage _componentsStorage;
        private Mover _mover;
        
        public AsteroidComponentsStorageBuilder()
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
            collider.IsTrigger = false;
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

            _mover = new Mover(_componentsStorage,
                new Vector3(Mathf.Cos(_componentsStorage.Transform.EulerAngles.Z * Mathf.Deg2Rad),
                    Mathf.Sin(_componentsStorage.Transform.EulerAngles.Z * Mathf.Deg2Rad), 0f),
                velocity, angularVelocity, isRotateObject);
            
            _componentsStorage.AddComponent(_mover);
            
            _updater.MovementObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
                (_mover, _updater.MovementObservable));
        }

        public override void BuildMoveInRectangle(Rectangle boundary)
        {
            base.BuildMoveInRectangle(boundary);
            
            var moveInRectangle = new MoveInRectangle(_componentsStorage, boundary);
            
            _componentsStorage.AddComponent(moveInRectangle);
            
            _updater.MovementObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
                (moveInRectangle, _updater.MovementObservable));
        }

        public override void BuildSpawnChildren()
        {
            base.BuildSpawnChildren();

            _mover.Destruction += _childrenSpawner.SpawnChildren;
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