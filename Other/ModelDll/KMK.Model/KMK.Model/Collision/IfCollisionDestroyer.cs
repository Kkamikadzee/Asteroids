namespace KMK.Model.Collision
{
    public static class IfCollisionDestroyer
    {
        public static void Destroy(Collider collider)
        {
            collider.Destroy();
        }
    }
}