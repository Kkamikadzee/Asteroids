using System;
using KMK.Models.Base;
using KMK.Models.Updater;

namespace KMK.Models.Move
{
    public class RotationController: Component, IAccelerationController, IUpdatable
    {
        private IAngularVelocityMover _mover;
        private float _maxAngularVelocity;
        private float _angularAcceleration;
        private float _angularDrag;

        public event Action<RotationController> Destruction;

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
            if (_mover.AngularVelocity + _angularAcceleration < _maxAngularVelocity)
            {
                _mover.AddAngularVelocity(_angularAcceleration);
            }
        }

        public void Decelerate()
        {
            if (_mover.AngularVelocity - _angularAcceleration > - _maxAngularVelocity)
            {
                _mover.AddAngularVelocity(-_angularAcceleration);
            }
        }

        public void Update(float deltaTime)
        {
            _mover.AddAngularVelocity(-(_angularDrag * deltaTime));
        }
        
        public override void Destroy()
        {
            base.Destroy();

            Destruction?.Invoke(this);
        }
    }
}