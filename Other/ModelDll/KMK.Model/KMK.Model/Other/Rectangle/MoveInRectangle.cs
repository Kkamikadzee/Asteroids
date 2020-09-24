using System;
using KMK.Model.Base;
using KMK.Model.Updater;

namespace KMK.Model.Other.Rectangle
{
    public class MoveInRectangle: Component, IUpdatable, IDestroyable
    {
        private IRectangle _boundary;
        private float _teleportDelta;

        public event Action<MoveInRectangle> Destruction;
        public event Action DisconnectFromObserver;

        //На +teleportDelta объект смещается при перемещение на противоположную сторону
        public MoveInRectangle(IComponentsStorage parent,
            IRectangle boundary, float teleportDelta = 0.001f) : base(parent)
        {
            _boundary = boundary;
            _teleportDelta = teleportDelta;
        }

        private void _update()
        {
            var LeftBottomPointBorder = _boundary.LeftBottomPoint;
            var RightTopPointBorder = _boundary.RightTopPoint;

            if ((Transform.Position.X) < LeftBottomPointBorder.X)
            {
                Transform.MoveTo(RightTopPointBorder.X - (_boundary.Width * _teleportDelta),
                    Transform.Position.Y, Transform.Position.Z);
            }
            else if ((Transform.Position.X) > RightTopPointBorder.X)
            {
                Transform.MoveTo(LeftBottomPointBorder.X + (_boundary.Width * _teleportDelta),
                    Transform.Position.Y, Transform.Position.Z);
            }
            else if ((Transform.Position.Y) < LeftBottomPointBorder.Y)
            {
                Transform.MoveTo(Transform.Position.Y,
                    RightTopPointBorder.Y - (_boundary.Height * _teleportDelta)
                    , Transform.Position.Z);
            }
            else if ((Transform.Position.Y) > RightTopPointBorder.Y)
            {
                Transform.MoveTo(Transform.Position.Y,
                    LeftBottomPointBorder.Y + (_boundary.Height * _teleportDelta)
                    , Transform.Position.Z);
            }
        }
        
        public void Update(float deltaTime)
        {
            if (_boundary.InRectangle(Transform.Position))
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