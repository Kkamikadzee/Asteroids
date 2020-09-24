using KMK.Model.Base;

namespace KMK.Model.Other.Rectangle
{
    public class Rectangle : IRectangle, IScalableRectangle
    {
        private float _width;
        private float _height;
        private Vector3 _center;

        public Rectangle(float width, float height, Vector3 center)
        {
            _width = width;
            _height = height;
            _center = center;
        }

        public float Width
        {
            get => _width;
            set
            {
                if (value >= 0)
                {
                    _width = value;
                }
            }
        }

        public float Height
        {
            get => _height;
            set
            {
                if (value >= 0)
                {
                    _height = value;
                }
            }
        }

        public Vector3 LeftBottomPoint => 
            new Vector3()
            {
                X = _center.X - _width / 2f,
                Y = _center.Y - _height / 2f,
                Z = _center.Z
            };
        
        public Vector3 LeftTopPoint => 
            new Vector3()
            {
                X = _center.X - _width / 2f,
                Y = _center.Y + _height / 2f,
                Z = _center.Z
            };

        public Vector3 RightBottomPoint =>
            new Vector3()
            {
                X = _center.X + _width / 2f,
                Y = _center.Y - _height / 2f,
                Z = _center.Z
            };
        
        public Vector3 RightTopPoint =>
            new Vector3()
            {
                X = _center.X + _width / 2f,
                Y = _center.Y + _height / 2f,
                Z = _center.Z
            };

        public bool InRectangle(Vector3 point)
        {
            return ((point.X > _center.X - _width / 2)
                    && (point.X < _center.X + _width / 2)
                    && (point.Y > _center.Y - _height / 2)
                    && (point.Y < _center.Y + _height / 2));
        }
        
        public bool InRectangle(Transform transform)
        {
            return (((transform.Position.X - transform.Scale.X / 2f) > _center.X - _width / 2)
                    && ((transform.Position.X + transform.Scale.X / 2f) < _center.X + _width / 2)
                    && ((transform.Position.Y - transform.Scale.Y / 2f) > _center.Y - _height / 2)
                    && ((transform.Position.Y + transform.Scale.Y / 2f) < _center.Y + _height / 2));
        }

        public void SetScale(float width, float height)
        {
            if (width >= 0 && height >= 0)
            {
                _width = width;
                _height = height;
            }
        }
    }
}