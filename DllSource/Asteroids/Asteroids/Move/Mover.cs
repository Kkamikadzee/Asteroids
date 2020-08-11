using System;
using KMK.Models.Base;
using KMK.Models.Updater;

namespace KMK.Models.Move
{
    public class Mover: Component, IDirectionMover, IVelocityMover, IAngularVelocityMover, IUpdatable
    {
        private Vector3 _directionMove;
        private float _velocity;
        private float _angularVelocity;
        private bool _isRotateObject;

        public event Action<Mover> Destruction;
        
        public Vector3 DirectionMove
        {
            get => _directionMove;
            set => _directionMove = value;
        }
        public float Velocity => _velocity;
        public float AngularVelocity => _angularVelocity;
        public bool IsRotateObject
        {
            get => _isRotateObject;
            set => _isRotateObject = value;
        }

        public Mover(IComponentsStorage parent) : base(parent) { }

        public Mover(IComponentsStorage parent, Vector3 directionMove,
            bool isRotateObject = false) : base(parent)
        {
            _directionMove = directionMove;
            _isRotateObject = isRotateObject;
        }
        
        public void AddVelocity(float delta)
        {
            _velocity += delta;
        }
        
        public void AddAngularVelocity(float delta)
        {
            _angularVelocity += delta;
        }

        public void Update(float deltaTime)
        {
            Transform.Translate(_directionMove * (_velocity * deltaTime));
            Transform.TurnOn(0, 0,
                _angularVelocity * deltaTime);
        }

        public override void Destroy()
        {
            base.Destroy();

            Destruction?.Invoke(this);
        }
    }
}