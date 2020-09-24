using KMK.Model.Base;
using KMK.Model.Collision;
using KMK.Model.Move;
using KMK.Model.Other.Pursuer;
using KMK.Model.Other.Rectangle;
using KMK.Model.Scorer;
using UnityEngine;
using Update;
using SphereCollider = KMK.Model.Collision.SphereCollider;
using Transform = KMK.Model.Base.Transform;
using Vector3 = KMK.Model.Base.Vector3;

namespace Model.Builder
{
    public class UfoComponentsStorageBuilder: KMK.Model.Builder.ComponentsStorageBuilder
    {
        private IUpdater _updater;
        private ICollisionChecker _collisionChecker;
        private IScorer _score;

        private IComponentsStorage _componentsStorage;

        private Mover _mover;
        private MotionController _motionController;

        public UfoComponentsStorageBuilder(IUpdater updater, ICollisionChecker collisionChecker,
            IScorer score)
        {
            _updater = updater;
            _collisionChecker = collisionChecker;
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

        public override void BuildMotionController(float maxVelocity, float acceleration, float drag)
        {
            base.BuildMotionController(maxVelocity, acceleration, drag);
            
            _motionController = new MotionController(_componentsStorage, _mover, maxVelocity, acceleration, drag);
            
            _componentsStorage.AddComponent(_motionController);
            
            _updater.MovementObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
                (_motionController, _updater.MovementObservable));
        }

        public override void BuildMoveInRectangle(Rectangle boundary)
        {
            base.BuildMoveInRectangle(boundary);
            
            var moveInRectangle = new MoveInRectangle(_componentsStorage, boundary);
            
            _componentsStorage.AddComponent(moveInRectangle);
            
            _updater.MovementObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
                (moveInRectangle, _updater.MovementObservable));
        }

        public override void BuildScoreGiver(float score)
        {
            base.BuildScoreGiver(score);
            
            var giver = new ScoreGiver(_componentsStorage, score);
            
            _componentsStorage.AddComponent(giver);

            giver.Give += _score.AddScore;
        }

        public override void BuildPursuer(float pursuitRadius, Transform pursued)
        {
            base.BuildPursuer(pursuitRadius, pursued);
            
            var pursuer = new Pursuer(_componentsStorage, pursuitRadius);
            var pointer = new PursuerPointer(_componentsStorage, pursuer, pursued);
            var moveStrategy = new SimplePursuerMoveStrategy(_componentsStorage, pursuer, _mover, _motionController);
            
            _componentsStorage.AddComponent(pursuer);
            _componentsStorage.AddComponent(pointer);
            _componentsStorage.AddComponent(moveStrategy);
            
            _updater.OtherUpdateObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
                (pointer, _updater.OtherUpdateObservable));
            _updater.OtherUpdateObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
                (moveStrategy, _updater.OtherUpdateObservable));
        }
    }
}