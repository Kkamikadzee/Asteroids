using System;

namespace Convert
{
    public static class KmkVector3Extension
    {
        private static double _TOLERANCE = 1e-6;    
        public static bool IsEquivalentTo(this KMK.Model.Base.Vector3 a, UnityEngine.Vector3 b)
        {
            return (Math.Abs(a.X - b.x) < _TOLERANCE) 
            && (Math.Abs(a.Y - b.y) < _TOLERANCE) 
            && (Math.Abs(a.Z - b.z) < _TOLERANCE);
        }
    }
}