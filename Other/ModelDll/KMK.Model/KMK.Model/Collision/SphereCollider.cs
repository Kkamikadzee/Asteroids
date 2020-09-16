using KMK.Model.Base;

namespace KMK.Model.Collision
{
    public class SphereCollider : Collider
    {
        private float _radius;
        private Vector3 _centerPosition;

        public float Radius => _radius;
        public Vector3 CenterPosition => _centerPosition;

        public SphereCollider(IComponentsStorage parent, ColliderTag tag,
            float radius) : base(parent, tag)
        {
            _radius = radius;
            _centerPosition = Transform.Position;
        }
        
        public SphereCollider(IComponentsStorage parent, ColliderTag tag,
            float radius, Vector3 centerPosition) : base(parent, tag)
        {
            _radius = radius;
            _centerPosition = centerPosition;
        }
    }
}