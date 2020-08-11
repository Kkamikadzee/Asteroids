using System;
using KMK.Models.Base;
using KMK.Models.Other.Bounce;
using KMK.Models.Updater;

namespace KMK.Models.Other.Rectangle
{
    public class BouncingInRectangle: Component, IUpdatable, IDestroyable
    {
        private IRectangle _boundary;
        private IBounce _bounce;
        
        public event Action<BouncingInRectangle> Destruction;

        public BouncingInRectangle(IComponentsStorage parent,
            IRectangle boundary, IBounce bounce) : base(parent)
        {
            _boundary = boundary;
            _bounce = bounce;
        }

        private void _update()
        {
            var LeftBottomPointBorder = _boundary.LeftBottomPoint;
            var RightTopPoint = _boundary.RightTopPoint;

            if ((Transform.Position.X - Transform.Scale.X / 2f) < LeftBottomPointBorder.X)
            {
                _bounce.Bounce(Vector3.Right);
            }
            else if ((Transform.Position.X + Transform.Scale.X / 2f) > LeftBottomPointBorder.X)
            {
                _bounce.Bounce(Vector3.Left);
            }
            else if ((Transform.Position.Y - Transform.Scale.Y / 2f) < LeftBottomPointBorder.Y)
            {
                _bounce.Bounce(Vector3.Up);
            }
            else if ((Transform.Position.Y + Transform.Scale.Y / 2f) > LeftBottomPointBorder.Y)
            {
                _bounce.Bounce(Vector3.Down);
            }
        }
        
        public void Update(float deltaTime)
        {
            if (_boundary.InRectangle(Transform))
            {
                return;
            }

            _update();
        }

        public override void Destroy()
        {
            base.Destroy();

            Destruction?.Invoke(this);
        }
    }
}