namespace KMK.Model.Base
{
    public interface IRotatable
    {
        Vector3 EulerAngles { get; }

        void Rotate(float x, float y, float z);
        void Rotate(Vector3 vector);
        void TurnOn(float x, float y, float z);
        void TurnOn(Vector3 vector);
    }
}