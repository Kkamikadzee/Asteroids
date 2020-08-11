using System;
using KMK.Models.Base;
using KMK.Models.Updater;

namespace KMK.Models.Move
{
    public class MotionController: Component, IAccelerationController, IUpdatable
    {
        private IVelocityMover _mover;
        private float _maxVelocity;
        private float _acceleration;
        private float _drag;

        public event Action<MotionController> Destruction;

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
            if (_mover.Velocity + _acceleration < _maxVelocity)
            {
                _mover.AddVelocity(_acceleration);
            }
        }

        public void Decelerate()
        {
            if (_mover.Velocity - _acceleration > - _maxVelocity)
            {
                _mover.AddVelocity(-_acceleration);
            }
        }

        public void Update(float deltaTime)
        {
            _mover.AddVelocity(-(_drag * deltaTime));
        }
        
        public override void Destroy()
        {
            base.Destroy();

            Destruction?.Invoke(this);
        }
    }
}