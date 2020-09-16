namespace KMK.Model.Move
{
    public interface IAngularVelocityMover
    {
        float AngularVelocity { get; }
        bool IsRotateObject { set; get; }

        void AddAngularVelocity(float delta);
    }
}