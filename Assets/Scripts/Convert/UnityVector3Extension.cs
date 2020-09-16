using System;

namespace Convert
{
    public static class UnityVector3Extension
    {
        private static double _TOLERANCE = 1e-6;    
        public static bool IsEquivalentTo(this UnityEngine.Vector3 a, KMK.Model.Base.Vector3 b)
        {
            return (Math.Abs(a.x - b.X) < _TOLERANCE) 
                   && (Math.Abs(a.y - b.Y) < _TOLERANCE) 
                   && (Math.Abs(a.z - b.Z) < _TOLERANCE);
        }
    }
}