using System;
using KMK.Model.Base;
using KMK.Model.Updater;

namespace KMK.Model.Move
{
    public class MotionController: Component, IAccelerationController, IUpdatable
    {
        private IVelocityMover _mover;
        private float _maxVelocity;
        private float _acceleration;
        private float _drag;

        public event Action<MotionController> Destruction;
        public event Action DisconnectFromObserver;

        public MotionController(IComponentsStorage parent,
            IVelocityMover mover, float maxVelocity, 
            float acceleration, float drag) : base(parent)
        {
            _mover = mover;
            _maxVelocity = maxVelocity;
            _acceleration = acceleration;
            _drag = drag;
        }

        public void Accelerate()
        {
            if (_mover.Velocity + _acceleration <= _maxVelocity)
            {
                _mover.AddVelocity(_acceleration);
            }
            else
            {
                _mover.AddVelocity(_maxVelocity - _mover.Velocity);
            }
        }

        public void Decelerate()
        {
            if (-_maxVelocity <= _mover.Velocity - _acceleration)
            {
                _mover.AddVelocity(-_acceleration);
            }
            else
            {
                _mover.AddVelocity(-_maxVelocity - _mover.Velocity);
            }
        }

        public void Update(float deltaTime)
        {
            if (_mover.Velocity != 0)
            {
                if (_mover.Velocity > 0)
                {
                    if (_mover.Velocity - (_drag * deltaTime) <= 0f)
                    {
                        _mover.AddVelocity(-_mover.Velocity);
                    }
                    else
                    {
                        _mover.AddVelocity(-(_drag * deltaTime));
                    }
                }
                else
                {
                    if (_mover.Velocity + (_drag * deltaTime) <= 0f)
                    {
                        _mover.AddVelocity(-_mover.Velocity);
                    }
                    else
                    {
                        _mover.AddVelocity((_drag * deltaTime));
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