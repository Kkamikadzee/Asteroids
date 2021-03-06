﻿using Controller.Game;
using Controller.UI;
using Input;
using KMK.Model.Adapter;
using KMK.Model.Base;
using KMK.Model.Collision;
using KMK.Model.Destroyer;
using KMK.Model.Move;
using KMK.Model.Other.Rectangle;
using KMK.Model.Weapon;
using Spawner.ChildrenSpawner;
using UnityEngine;
using Update;
using SphereCollider = KMK.Model.Collision.SphereCollider;
using Transform = KMK.Model.Base.Transform;
using Vector3 = KMK.Model.Base.Vector3;

namespace Model.Builder
{
    public class PlayerComponentsStorageBuilder: KMK.Model.Builder.ComponentsStorageBuilder
    {
        private IUpdater _updater;
        private IDestroyer _destroyer;
        
        private IAsteroidsUiControllersStoragePlayerInfo _uiControllers;
        private ICollisionChecker _collisionChecker;
        private HealthDieController _healthController;
        private ChildrenSpawner _cannonChildrenSpawner;
        private ChildrenSpawner _laserChildrenSpawner;
        private PlayerInputController _playerInputController;
        
        private IComponentsStorage _componentsStorage;
        private Mover _mover;
        
        private MotionController _motionController;
        private RotationController _rotationController;
        
        private Weapon _weapon1;
        private AutoAddLimitedAmmoWeapon _weapon2;

        public PlayerComponentsStorageBuilder(IUpdater updater, IDestroyer destroyer, 
            IAsteroidsUiControllersStoragePlayerInfo uiControllers,
            ICollisionChecker collisionChecker, HealthDieController healthController, 
            ChildrenSpawner cannonChildrenSpawner, ChildrenSpawner laserChildrenSpawner,
            PlayerInputController playerInputController)
        {
            _updater = updater;
            _destroyer = destroyer;
            
            _uiControllers = uiControllers;
            _collisionChecker = collisionChecker;
            _healthController = healthController;
            _cannonChildrenSpawner = cannonChildrenSpawner;
            _laserChildrenSpawner = laserChildrenSpawner;
            _playerInputController = playerInputController;
        }
        
        public override IComponentsStorage GetIComponentsStorage()
        {
            _playerInputController.SetPlayerRef(_motionController, _rotationController,
                _weapon1, _weapon2);

            _componentsStorage.Destruction += _playerInputController.ClearPlayerRefs;

            _componentsStorage.Destruction += _healthController.SubHealth;

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

        public override void BuildRotationController(float maxAngularVelocity, float angularAcceleration, float angularDrag)
        {
            base.BuildRotationController(maxAngularVelocity, angularAcceleration, angularDrag);

            _rotationController = new RotationController(_componentsStorage, _mover, maxAngularVelocity, angularAcceleration, angularDrag);
            
            _componentsStorage.AddComponent(_rotationController);
            
            _updater.MovementObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
                (_rotationController, _updater.MovementObservable));
        }

        public override void BuildWeapon(float firerate)
        {
            base.BuildWeapon(firerate);
            
            _weapon1 = new Weapon(_componentsStorage, firerate);
            
            _componentsStorage.AddComponent(_weapon1);
            
            _updater.OtherFixedUpdateObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
                (_weapon1, _updater.OtherFixedUpdateObservable));

            _weapon1.Shot += _cannonChildrenSpawner.SpawnChildren;
        }

        public override void BuildAutoReloadableWeapon(float firerate, float autoAddAmmoTime, int maxAmountAmmo)
        {
            base.BuildAutoReloadableWeapon(firerate, autoAddAmmoTime, maxAmountAmmo);
            
            _weapon2 = new AutoAddLimitedAmmoWeapon(_componentsStorage, firerate, maxAmountAmmo, autoAddAmmoTime);
            
            _componentsStorage.AddComponent(_weapon2);
            
            _updater.OtherFixedUpdateObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
                (_weapon2, _updater.OtherFixedUpdateObservable));

            _weapon2.Shot += _laserChildrenSpawner.SpawnChildren;

            var adapterProgress = new ProgressIndicatorAutoAddAmmoAdapter(_weapon2);
            if (_uiControllers.ReloadLaser is ProgressIndicatorController progressIndicatorController)
            {
                progressIndicatorController.ProgressIndicator = adapterProgress;
            }
            
            var adapterResource = new LimitedResourceAmmoAdapter(_weapon2);
            if (_uiControllers.LaserAmmo is LimitedResourceLimitedFromAboveController laserAmmoController)
            {
                laserAmmoController.LimitedResource = adapterResource;
            }
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