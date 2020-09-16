using KMK.Model.Base;
using KMK.Model.Move;

namespace KMK.Model.Other.Bounce
{
    public class BouncingComponent: Component, IBounce
    {
        private IDirectionMover _directionMover;

        public BouncingComponent(IComponentsStorage parent,
            IDirectionMover directionMover) : base(parent)
        {
            _directionMover = directionMover;
        }


        public void Bounce(Vector3 inNormal)
        {
            _directionMover.DirectionMove =
                Vector3.Reflect(_directionMover.DirectionMove, inNormal);
        }

        public void Bounce(float x, float y, float z)
        {
            Bounce(new Vector3(x, y, z));
        }
    }
}