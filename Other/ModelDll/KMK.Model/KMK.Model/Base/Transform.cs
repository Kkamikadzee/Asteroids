namespace KMK.Model.Base
{
    public class Transform : IMovable, IRotatable, IScalable
    {
        private Vector3 _position;
        private Vector3 _eulerAngles;
        private Vector3 _scale;

        public Vector3 Position => _position;
        public Vector3 EulerAngles => _eulerAngles;

        public Vector3 Scale
        {
            get => _scale;
            set
            {
                if (value.X >= 0 && value.Y >= 0 && value.Z >= 0)
                {
                    _scale = value;
                }
            }
        }

        public Transform()
        {
            _position = new Vector3();
            _eulerAngles = new Vector3();
            _scale = Vector3.One;
        }
        
        public Transform(Vector3 position)
        {
            _position = position;
            _eulerAngles = new Vector3();
            _scale = Vector3.One;
        }
        
        public Transform(Vector3 position, Vector3 eulerAngles)
        {
            _position = position;
            _eulerAngles = eulerAngles;
            _scale = Vector3.One;
        }
        
        public Transform(Vector3 position, Vector3 eulerAngles, Vector3 scale)
        {
            _position = position;
            _eulerAngles = eulerAngles;
            
            if (scale.X >= 0 && scale.Y >= 0 && scale.Z >= 0)
            {
                _scale = scale;
            }
            else
            {
                _scale = Vector3.One;
            }
        }

        public Transform(Transform transform)
        {
            _position = transform._position;
            _eulerAngles = transform._eulerAngles;
            _scale = transform._scale;
        }
        
        public void MoveTo(float x, float y, float z)
        {
            _position.X = x;
            _position.Y = y;
            _position.Z = z;
        }

        public void MoveTo(Vector3 vector)
        {
            _position = vector;
        }

        public void Translate(float x, float y, float z)
        {
            _position.X += x;
            _position.Y += y;
            _position.Z += z;
        }

        public void Translate(Vector3 vector)
        {
            _position += vector;
        }
        
        public void Rotate(float x, float y, float z)
        {
            _eulerAngles.X = x;
            _eulerAngles.Y = y;
            _eulerAngles.Z = z;
        }

        public void Rotate(Vector3 vector)
        {
            _eulerAngles = vector;
        }

        public void TurnOn(float x, float y, float z)
        {
            _eulerAngles.X += x;
            _eulerAngles.Y += y;
            _eulerAngles.Z += z;
        }

        public void TurnOn(Vector3 vector)
        {
            _eulerAngles += vector;
        }
    }
}