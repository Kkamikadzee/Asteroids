namespace KMK.Models.Base
{
    public interface IMovable
    {
        Vector3 Position { get; }

        void MoveTo(float x, float y, float z);
        void MoveTo(Vector3 vector);
        void Translate(float x, float y, float z);
        void Translate(Vector3 vector);
    }
}