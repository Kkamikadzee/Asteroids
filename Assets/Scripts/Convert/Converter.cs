namespace Convert
{
    public static class Converter
    {
        public static UnityEngine.Vector3 ToVector3(KMK.Model.Base.Vector3 vector3)
        {
            return new UnityEngine.Vector3(vector3.X, vector3.Y, vector3.Z);
        }
        public static KMK.Model.Base.Vector3 ToVector3(UnityEngine.Vector3 vector3)
        {
            return new KMK.Model.Base.Vector3(vector3.x, vector3.y, vector3.z);
        }
    }
}