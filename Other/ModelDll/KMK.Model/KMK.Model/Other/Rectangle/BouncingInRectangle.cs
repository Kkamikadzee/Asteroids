using System;
using KMK.Model.Base;
using KMK.Model.Other.Bounce;
using KMK.Model.Updater;

namespace KMK.Model.Other.Rectangle
{
    public class BouncingInRectangle: Component, IUpdatable, IDestroyable
    {
        private IRectangle _boundary;
        private IBounce _bounce;
        
        private float _teleportDelta;

        public event Action<BouncingInRectangle> Destruction;
        public event Action DisconnectFromObserver;

        //На +teleportDelta объект смещается при рикошете на противоположную сторону
        public BouncingInRectangle(IComponentsStorage parent,
            IRectangle boundary, IBounce bounce, float teleportDelta = 0.001f) : base(parent)
        {
            _boundary = boundary;
            _bounce = bounce;
            _teleportDelta = teleportDelta;
        }

        private void _update()
        {
            var LeftBottomPointBorder = _boundary.LeftBottomPoint;
            var RightTopPoint = _boundary.RightTopPoint;

            if ((Transform.Position.X) < LeftBottomPointBorder.X)
            {
                Transform.Translate(_teleportDelta, 0 , 0f);
                _bounce.Bounce(Vector3.Right);
            }
            else if ((Transform.Position.X) > RightTopPoint.X)
            {
                Transform.Translate(- _teleportDelta, 0 , 0f);
                _bounce.Bounce(Vector3.Left);
            }
            else if ((Transform.Position.Y) < LeftBottomPointBorder.Y)
            {
                Transform.Translate(0, _teleportDelta, 0f);
                _bounce.Bounce(Vector3.Up);
            }
            else if ((Transform.Position.Y) > RightTopPoint.Y)
            {
                Transform.Translate(0, - _teleportDelta, 0f);
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
            
            DisconnectFromObserver?.Invoke();
            Destruction?.Invoke(this);
        }
    }
}