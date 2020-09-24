using System;
using KMK.Model.Base;
using KMK.Model.Updater;

namespace KMK.Model.Move
{
    public class RotationController: Component, IAccelerationController, IUpdatable
    {
        private IAngularVelocityMover _mover;
        private float _maxAngularVelocity;
        private float _angularAcceleration;
        private float _angularDrag;

        public event Action<RotationController> Destruction;
        public event Action DisconnectFromObserver;

        public RotationController(IComponentsStorage parent,
            IAngularVelocityMover mover, float maxAngularVelocity, 
            float angularAcceleration, float angularDrag) : base(parent)
        {
            _mover = mover;
            _maxAngularVelocity = maxAngularVelocity;
            _angularAcceleration = angularAcceleration;
            _angularDrag = angularDrag;
        }

        public void Accelerate()
        {
            if (_mover.AngularVelocity + _angularAcceleration <= _maxAngularVelocity)
            {
                _mover.AddAngularVelocity(_angularAcceleration);
            }
            else
            {
                _mover.AddAngularVelocity(_maxAngularVelocity - _mover.AngularVelocity);
            }
        }

        public void Decelerate()
        {
            if (-_maxAngularVelocity <= _mover.AngularVelocity - _angularAcceleration)
            {
                _mover.AddAngularVelocity(-_angularAcceleration);
            }
            else
            {
                _mover.AddAngularVelocity(-_maxAngularVelocity - _mover.AngularVelocity);
            }
        }

        public void Update(float deltaTime)
        {
            if (_mover.AngularVelocity != 0)
            {
                if (_mover.AngularVelocity > 0)
                {
                    if (_mover.AngularVelocity - (_angularDrag * deltaTime) <= 0f)
                    {
                        _mover.AddAngularVelocity(-_mover.AngularVelocity);
                    }
                    else
                    {
                        _mover.AddAngularVelocity(-(_angularDrag * deltaTime));
                    }
                }
                else
                {
                    if (_mover.AngularVelocity + (_angularDrag * deltaTime) >= 0f)
                    {
                        _mover.AddAngularVelocity(-_mover.AngularVelocity);
                    }
                    else
                    {
                        _mover.AddAngularVelocity((_angularDrag * deltaTime));
                    }
                }
            }
        }
        
        public override void Destroy()
        {
            base.Destroy();

            DisconnectFromObserver?.Invoke();
            Destruction?.Invoke(this);
        }
    }
}