using KMK.Model.Base;

namespace KMK.Model.Other.Bounce
{
    public interface IBounce
    {
        void Bounce(Vector3 inNormal);
        void Bounce(float x, float y, float z);
    }
}