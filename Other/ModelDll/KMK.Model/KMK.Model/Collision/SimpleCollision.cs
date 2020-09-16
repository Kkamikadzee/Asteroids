using KMK.Model.Base;

namespace KMK.Model.Collision
{
    public class SimpleCollision : ICollision
    {
        public bool OnCollision(Collider firstCollider, 
            Collider secondCollider)
        {
            if ((firstCollider is SphereCollider collider1)
                && (secondCollider is SphereCollider collider2))
            {
                return OnCollision(collider1, collider2);
            }

            return false;
        }
        public bool OnCollision(SphereCollider firstCollider, 
            SphereCollider secondCollider)
        {
            return (firstCollider.Radius + secondCollider.Radius)
                   <= Vector3.Distance(firstCollider.CenterPosition
                       , secondCollider.CenterPosition);
        }
    }
}