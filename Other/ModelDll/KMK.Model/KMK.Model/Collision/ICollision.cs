namespace KMK.Model.Collision
{
    public interface ICollision
    {
        bool OnCollision(Collider firstCollider, Collider secondCollider);
        bool OnCollision(SphereCollider firstCollider, SphereCollider secondCollider);
    }
}