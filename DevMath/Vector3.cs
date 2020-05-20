using System;

namespace DevMath
{
    public struct Vector3
    {
        public static readonly Vector3 zero = new Vector3(0, 0, 0);

        public float x;
        public float y;
        public float z;

        public float this[int key]
        {
            get => key == 0 ? x : key == 1 ? y : key == 2 ? z : throw new IndexOutOfRangeException();
            set
            {
                if(key == 0)
                {
                    x = value;
                    return;
                }
                else if(key == 1)
                {
                    y = value;
                    return;
                }
                else if(key == 2)
                {
                    z = value;
                    return;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public float SquaredMagnitude => (x * x) + (y * y) + (z * z);
        public float Magnitude => DevMath.SquareRoot(SquaredMagnitude);
        public Vector3 Normalized => this * (1 / Magnitude);

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static implicit operator Vector3(Vector2 v) => new Vector3(v.x, v.y, 0);

        public static float Dot(Vector3 v, Vector3 w)
        {
            Vector3 vNormalized = v.Normalized;
            Vector3 wNormalized = w.Normalized;

            return vNormalized.x * wNormalized.x + vNormalized.y * wNormalized.y + vNormalized.z * wNormalized.z;
        }

        public static Vector3 Cross(Vector3 v, Vector3 w)
        {
            float uX = v.y * w.z - v.z * w.y;
            float uY = v.z * w.x - v.x * w.z;
            float uZ = v.x * w.y - v.y * w.x;
            return new Vector3(uX, uY, uZ);
        }

        public static Vector3 Scale(Vector3 v, Vector3 w)
        {
            float uX = v.x * w.x;
            float uY = v.y * w.y;
            float uZ = v.z * w.z;
            return new Vector3(uX, uY, uZ);
        }

        public static Vector3 Lerp(Vector3 a, Vector3 b, float t) => LerpUnclamped(a, b, DevMath.Clamp01(t));
        public static Vector3 LerpUnclamped(Vector3 a, Vector3 b, float t)
        {
            float uX = DevMath.LerpUnclamped(a.x, b.x, t);
            float uY = DevMath.LerpUnclamped(a.y, b.y, t);
            float uZ = DevMath.LerpUnclamped(a.z, b.z, t);
            return new Vector3(uX, uY, uZ);
        }

        public static float Distance(Vector3 v, Vector3 w) => (v - w).Magnitude;
        public static float SquaredDistance(Vector3 v, Vector3 w) => (v - w).SquaredMagnitude;

        public static Vector3 operator +(Vector3 lhs, Vector3 rhs) => new Vector3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        public static Vector3 operator -(Vector3 lhs, Vector3 rhs) => new Vector3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        public static Vector3 operator -(Vector3 v) => new Vector3(-v.x, -v.y, -v.z);
        public static Vector3 operator *(Vector3 lhs, float scalar) => new Vector3(lhs.x * scalar, lhs.y * scalar, lhs.z * scalar);
        public static Vector3 operator /(Vector3 lhs, float scalar) => new Vector3(lhs.x * scalar, lhs.y * scalar, lhs.z * scalar);
        public static bool operator !=(Vector3 lhs, Vector3 rhs) => !(lhs == rhs);
        public static bool operator ==(Vector3 lhs, Vector3 rhs) => lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z;

        public override bool Equals(object obj)
        {
            return obj is Vector3 vector3 && vector3 == this;
        }

        public override int GetHashCode()
        {
            return (x, y, z).GetHashCode();
        }

        public override string ToString()
        {
            return $"({x}, {y}, {z})";
        }
    }
}
