using KMK.Model.Base;

namespace KMK.Model.Other.Pursuer
{
    public interface IPursuer
    {
        void SetPositionPursued(float x, float y, float z);
        void SetPositionPursued(Vector3 position);
    }
}