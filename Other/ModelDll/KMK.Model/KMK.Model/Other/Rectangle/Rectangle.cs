using KMK.Model.Base;

namespace KMK.Model.Other.Rectangle
{
    public class Rectangle : Component, IRectangle, IScalableRectangle
    {
        private float _width;
        private float _height;

        public Rectangle(IComponentsStorage parent,
            float width, float height) : base(parent)
        {
            _width = width;
            _height = height;
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
                X = Transform.Position.X - _width / 2f,
                Y = Transform.Position.Y - _height / 2f,
                Z = Transform.Position.Z
            };
        
        public Vector3 LeftTopPoint => 
            new Vector3()
            {
                X = Transform.Position.X - _width / 2f,
                Y = Transform.Position.Y + _height / 2f,
                Z = Transform.Position.Z
            };

        public Vector3 RightBottomPoint =>
            new Vector3()
            {
                X = Transform.Position.X + _width / 2f,
                Y = Transform.Position.Y - _height / 2f,
                Z = Transform.Position.Z
            };
        
        public Vector3 RightTopPoint =>
            new Vector3()
            {
                X = Transform.Position.X + _width / 2f,
                Y = Transform.Position.Y + _height / 2f,
                Z = Transform.Position.Z
            };

        public bool InRectangle(Vector3 point)
        {
            return ((point.X > Transform.Position.X - _width / 2)
                    && (point.X < Transform.Position.X + _width / 2)
                    && (point.Y > Transform.Position.Y - _height / 2)
                    && (point.Y < Transform.Position.Y + _height / 2));
        }
        
        public bool InRectangle(Transform transform)
        {
            return (((transform.Position.X - transform.Scale.X / 2f) > Transform.Position.X - _width / 2)
                    && ((transform.Position.X + transform.Scale.X / 2f) < Transform.Position.X + _width / 2)
                    && ((transform.Position.Y - transform.Scale.Y / 2f) > Transform.Position.Y - _height / 2)
                    && ((transform.Position.Y + transform.Scale.Y / 2f) < Transform.Position.Y + _height / 2));
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