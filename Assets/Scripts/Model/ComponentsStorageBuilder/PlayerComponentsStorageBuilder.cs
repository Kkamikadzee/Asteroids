using Controller.Game;
using Controller.UI;
using KMK.Model.Adapter;
using KMK.Model.Base;
using KMK.Model.Collision;
using KMK.Model.Move;
using KMK.Model.Other.Rectangle;
using KMK.Model.Weapon;
using Spawner.ChildrenSpawner;
using UnityEngine;
using Update;
using View.UI;
using SphereCollider = KMK.Model.Collision.SphereCollider;
using Transform = KMK.Model.Base.Transform;
using Vector3 = KMK.Model.Base.Vector3;

namespace Model.ComponentsStorageBuilder
{
    public class PlayerComponentsStorageBuilder: KMK.Model.Builder.ComponentsStorageBuilder
    {
        private IUpdater _updater;
        private IAsteroidsUiControllersStoragePlayerInfo _uiControllers;
        private ICollisionChecker _collisionChecker;
        private HealthDieController _healthController;
        private IChildrenSpawnerHelper _cannonChildrenSpawner;
        private IChildrenSpawnerHelper _laserChildrenSpawner;

        private IComponentsStorage _componentsStorage;
        private Mover _mover;

        public PlayerComponentsStorageBuilder()
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

            _mover = new Mover(_componentsStorage,
                new Vector3(Mathf.Cos(_componentsStorage.Transform.EulerAngles.Z * Mathf.Deg2Rad),
                    Mathf.Sin(_componentsStorage.Transform.EulerAngles.Z * Mathf.Deg2Rad), 0f),
                velocity, angularVelocity, isRotateObject);
            
            _componentsStorage.AddComponent(_mover);
            
            _updater.MovementObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
                (_mover, _updater.MovementObservable));
        }

        public override void BuildMotionController(float maxVelocity, float acceleration, float drag)
        {
            base.BuildMotionController(maxVelocity, acceleration, drag);
            
            var controller = new MotionController(_componentsStorage, _mover, maxVelocity, acceleration, drag);
            
            _componentsStorage.AddComponent(controller);
            
            _updater.MovementObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
                (controller, _updater.MovementObservable));
            
            //TODO: Привязка к событиям инпутов для управления
        }

        public override void BuildRotationController(float maxAngularVelocity, float angularAcceleration, float angularDrag)
        {
            base.BuildRotationController(maxAngularVelocity, angularAcceleration, angularDrag);

            var controller = new RotationController(_componentsStorage, _mover, maxAngularVelocity, angularAcceleration, angularDrag);
            
            _componentsStorage.AddComponent(controller);
            
            _updater.MovementObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
                (controller, _updater.MovementObservable));
            
            //TODO: Привязка к событиям инпутов для управления
        }

        public override void BuildWeapon(float firerate)
        {
            base.BuildWeapon(firerate);
            
            var weapon = new Weapon(_componentsStorage, firerate);
            
            _componentsStorage.AddComponent(weapon);
            
            _updater.OtherFixedUpdateObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
                (weapon, _updater.OtherFixedUpdateObservable));

            weapon.Shot += _cannonChildrenSpawner.SpawnChildren;

            //TODO: Привязка к событиям инпутов для управления
        }

        public override void BuildAutoReloadableWeapon(float firerate, float autoAddAmmoTime, int maxAmountAmmo)
        {
            base.BuildAutoReloadableWeapon(firerate, autoAddAmmoTime, maxAmountAmmo);
            
            var weapon = new AutoAddLimitedAmmoWeapon(_componentsStorage, firerate, maxAmountAmmo, autoAddAmmoTime);
            
            _componentsStorage.AddComponent(weapon);
            
            _updater.OtherFixedUpdateObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
                (weapon, _updater.OtherFixedUpdateObservable));

            weapon.Shot += _laserChildrenSpawner.SpawnChildren;

            var adapterProgress = new ProgressIndicatorAutoAddAmmoAdapter(weapon);
            if (_uiControllers.ReloadLaser is ProgressIndicatorController progressIndicatorController)
            {
                progressIndicatorController.ProgressIndicator = adapterProgress;
            }
            
            var adapterResource = new LimitedResourceAmmoAdapter(weapon);
            if (_uiControllers.LaserAmmo is LimitedResourceLimitedFromAboveController laserAmmoController)
            {
                laserAmmoController.LimitedResource = adapterResource;
            }

            //TODO: Привязка к событиям инпутов для управления
        }

        public override void BuildMoveInRectangle(Rectangle boundary)
        {
            base.BuildMoveInRectangle(boundary);
            
            var moveInRectangle = new MoveInRectangle(_componentsStorage, boundary);
            
            _componentsStorage.AddComponent(moveInRectangle);
            
            _updater.MovementObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
                (moveInRectangle, _updater.MovementObservable));
        }
    }
}