using System;

namespace KMK.Model.Base
{
    public struct Vector3
    {
        private float _x, _y, _z;

        public float X
        {
            get => _x;
            set => _x = value;
        }
        public float Y
        {
            get => _y;
            set => _y = value;
        }
        public float Z
        {
            get => _z;
            set => _z = value;
        }

        public Vector3 Normalized => _normalized();
        public float Magnitude => _magnitude();
        
        public Vector3(float x, float y, float z)
        {
            _x = x;
            _y = y;
            _z = z;
        }
        public Vector3(Vector3 vector3)
        {
            _x = vector3._x;
            _y = vector3._y;
            _z = vector3._z;
        }

        private Vector3 _normalized()
        {
            return this / _magnitude();
        }
        
        private float _magnitude()
        {
            return Convert.ToSingle(Math.Sqrt(_x * _x + _y * _y + _z * _z));
        }

        public void Normalize()
        {
            float magnitude = _magnitude();
            _x /= magnitude;
            _y /= magnitude;
            _z /= magnitude;
        }

        public override string ToString()
        {
            return String.Format("({0}; {1}; {2})", _x, _y, _z);
        }

        public static float Distance(Vector3 a, Vector3 b)
        {
            return (a - b)._magnitude();
        }

        public static float Dot(Vector3 a, Vector3 b)
        {
            return a._x * b._x
                   + a._y * b._y
                   + a._z * b._z;
        }
        
        public static Vector3 Project(Vector3 vector, Vector3 onNormal)
        {
            float eps = 1e-6f;
            float numericProject = Dot(vector, onNormal);
            float magnitudeNormal = onNormal._magnitude();
            numericProject = magnitudeNormal >= eps ? numericProject / magnitudeNormal : 0;
            return onNormal * numericProject;
        }
        public static Vector3 Reflect(Vector3 inDirection, Vector3 inNormal)
        {
            inNormal.Normalize();
            return inDirection -
                   (2 * Vector3.Dot(inDirection, inNormal)) * inNormal;
        }
        
        public bool Equals(Vector3 other)
        {
            return _x.Equals(other._x) && _y.Equals(other._y) && _z.Equals(other._z);
        }

        public override bool Equals(object obj)
        {
            return obj is Vector3 other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _x.GetHashCode();
                hashCode = (hashCode * 397) ^ _y.GetHashCode();
                hashCode = (hashCode * 397) ^ _z.GetHashCode();
                return hashCode;
            }
        }
        
        /// <summary>
        /// Return Vector3(0, 0, -1)
        /// </summary>
        public static Vector3 Back => new Vector3(0, 0, -1);
        /// <summary>
        /// Return Vector3(0, -1, 0)
        /// </summary>
        public static Vector3 Down => new Vector3(0, -1, 0);
        /// <summary>
        /// Return Vector3(0, 0, 1)
        /// </summary>
        public static Vector3 Forward => new Vector3(0, 0, 1);
        /// <summary>
        /// Return Vector3(-1, 0, 0)
        /// </summary>
        public static Vector3 Left => new Vector3(-1, 0, 0);
        /// <summary>
        /// Return Vector3(1, 1, 1)
        /// </summary>
        public static Vector3 One => new Vector3(1, 1, 1);
        /// <summary>
        /// Return Vector3(1, 0, 0)
        /// </summary>
        public static Vector3 Right => new Vector3(1, 0, 0);
        /// <summary>
        /// Return Vector3(0, 1, 0)
        /// </summary>
        public static Vector3 Up => new Vector3(0, 1, 0);
        /// <summary>
        /// Return Vector3(0, 0, 0)
        /// </summary>
        public static Vector3 Zero => new Vector3(0, 0, 0);

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a._x + b._x, a._y + b._y, a._z + b._z);
        }
        public static Vector3 operator -(Vector3 a)
        {
            return new Vector3(-a._x, -a._y, -a._z);
        }
        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a._x - b._x, a._y - b._y, a._z - b._z);
        }
        public static Vector3 operator *(Vector3 a, float b)
        {
            return new Vector3(a._x * b, a._y * b, a._z * b);
        }
        public static Vector3 operator *(float a, Vector3 b)
        {
            return new Vector3(a * b._x, a * b._y, a * b._z);
        }
        public static Vector3 operator /(Vector3 a, float b)
        {
            return new Vector3(a._x / b, a._y / b, a._z / b);
        }
        public static bool operator !=(Vector3 a, Vector3 b)
        {
            return a._x != b._x || a._y != b._y || a._z != b._z;
        }
        public static bool operator ==(Vector3 a, Vector3 b)
        {
            return a._x == b._x && a._y == b._y && a._z == b._z;
        }
    }}