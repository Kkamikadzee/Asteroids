using System;
using KMK.Model.Base;
using KMK.Model.Updater;

namespace KMK.Model.Move
{
    public class Mover: Component, IDirectionMover, IVelocityMover, IAngularVelocityMover, IUpdatable
    {
        private Vector3 _directionMove;
        private float _velocity;

        private float _currentAngleZ;
        private float _angularVelocity; // deg per sec
        private bool _isRotateObject;

        public event Action<Mover> Destruction;
        public event Action DisconnectFromObserver;

        public Vector3 DirectionMove
        {
            get => _directionMove;
            set
            {
                _directionMove = value;
                if (_directionMove.Y >= 0)
                {
                    _currentAngleZ= (float)(Math.Acos(_directionMove.X) * 180 / Math.PI);
                }
                else
                {
                    _currentAngleZ = (float) -(Math.Acos(_directionMove.X) * 180 / Math.PI);
                }
            }
        }

        public float Velocity => _velocity;
        public float AngularVelocity => _angularVelocity;
        public bool IsRotateObject
        {
            get => _isRotateObject;
            set => _isRotateObject = value;
        }

        public Mover(IComponentsStorage parent) : base(parent) { }

        public Mover(IComponentsStorage parent, float angleDirectionMove,
            float velocity, float angularVelocity, 
            bool isRotateObject = false) : base(parent)
        {
            _currentAngleZ = angleDirectionMove;
            _directionMove = new Vector3(
                (float) Math.Cos(_currentAngleZ * Math.PI / 180f), 
                (float) Math.Sin(_currentAngleZ * Math.PI / 180f),
                0);

            _isRotateObject = isRotateObject;
            _velocity = velocity;
            _angularVelocity = angularVelocity;
        }
        
        public Mover(IComponentsStorage parent, Vector3 directionMove,
            float velocity, float angularVelocity, 
            bool isRotateObject = false) : base(parent)
        {
            
            _directionMove = directionMove;
            if (_directionMove.Y >= 0)
            {
                _angularVelocity= (float)(Math.Acos(_directionMove.X) * 180 / Math.PI);
            }
            else
            {
                _angularVelocity = (float) -(Math.Acos(_directionMove.X) * 180 / Math.PI);
            }
            
            _isRotateObject = isRotateObject;
            _velocity = velocity;
            _angularVelocity = angularVelocity;
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
            if (_velocity != 0)
            {
                Transform.Translate(_directionMove * (_velocity * deltaTime));
            }

            if (_angularVelocity != 0)
            {
                _currentAngleZ += (_angularVelocity * deltaTime) % 360f;

                _directionMove.X = (float) Math.Cos(_currentAngleZ * Math.PI / 180f);
                _directionMove.Y = (float) Math.Sin(_currentAngleZ * Math.PI / 180f);
            
                if (_isRotateObject)
                {
                    Transform.Rotate(0, 0,
                        _currentAngleZ);
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