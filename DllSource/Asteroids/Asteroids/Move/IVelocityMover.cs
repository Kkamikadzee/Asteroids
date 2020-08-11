namespace KMK.Models.Move
{
    public interface IVelocityMover
    {
        float Velocity { get; }

        void AddVelocity(float delta);
    }
}