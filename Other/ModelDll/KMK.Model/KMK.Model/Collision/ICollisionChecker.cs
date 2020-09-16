namespace KMK.Model.Collision
{
    public interface ICollisionChecker
    {
        void AddCollider(Collider collider);
        void RemoveCollider(Collider collider);
    }
}