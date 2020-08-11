using KMK.Models.Base;

namespace KMK.Models.Other.Pursuer
{
    public class Pursuer: Component, IPursuer
    {
        private Vector3 _positionPursued;
        private float _pursuitRadius;

        public float PursuitRadius => _pursuitRadius;
        public Vector3 PositionPursued => _positionPursued;

        public Pursuer(IComponentsStorage parent,
            float pursuitRadius) : base(parent)
        {
            _positionPursued = new Vector3();
            _pursuitRadius = pursuitRadius;
        }

        public void SetPositionPursued(float x, float y, float z)
        {
            _positionPursued.X = x;
            _positionPursued.Y = y;
            _positionPursued.Z = z;
        }
    }
}