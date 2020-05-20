using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public struct Vector4
    {
        public static readonly Vector4 zero = new Vector4(0, 0, 0, 0);

        public float x;
        public float y;
        public float z;
        public float w;

        public float this[int key]
        {
            get => key == 0 ? x : key == 1 ? y : key == 2 ? z : key == 3 ? w : throw new IndexOutOfRangeException();
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
                else if(key == 3)
                {
                    w = value;
                    return;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public float SquaredMagnitude => (x * x) + (y * y) + (z * z) + (w * w);
        public float Magnitude => DevMath.SquareRoot(SquaredMagnitude);
        public Vector4 Normalized => this * (1 / Magnitude);

        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public static implicit operator Vector4(Vector3 v) => new Vector4(v.x, v.y, v.z, 0);

        public static float Dot(Vector4 v, Vector4 w)
        {
            Vector4 vNormalized = v.Normalized;
            Vector4 wNormalized = w.Normalized;

            return vNormalized.x * wNormalized.x + vNormalized.y * wNormalized.y + vNormalized.z * wNormalized.z + wNormalized.w * wNormalized.w;
        }

        public static Vector4 Scale(Vector4 v, Vector4 w)
        {
            float uX = v.x * w.x;
            float uY = v.y * w.y;
            float uZ = v.z * w.z;
            float uW = v.w * w.w;
            return new Vector4(uX, uY, uZ, uW);
        }

        public static Vector4 Lerp(Vector4 a, Vector4 b, float t) => LerpUnclamped(a, b, DevMath.Clamp01(t));
        public static Vector4 LerpUnclamped(Vector4 a, Vector4 b, float t)
        {
            float uX = DevMath.LerpUnclamped(a.x, b.x, t);
            float uY = DevMath.LerpUnclamped(a.y, b.y, t);
            float uZ = DevMath.LerpUnclamped(a.z, b.z, t);
            float uW = DevMath.LerpUnclamped(a.w, b.w, t);
            return new Vector4(uX, uY, uZ, uW);
        }

        public static float Distance(Vector4 v, Vector4 w) => (v - w).Magnitude;
        public static float SquaredDistance(Vector4 v, Vector4 w) => (v - w).SquaredMagnitude;

        public static Vector4 operator +(Vector4 lhs, Vector4 rhs) => new Vector4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
        public static Vector4 operator -(Vector4 lhs, Vector4 rhs) => new Vector4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
        public static Vector4 operator -(Vector4 v) => new Vector4(-v.x, -v.y, -v.z, -v.w);
        public static Vector4 operator *(Vector4 lhs, float scalar) => new Vector4(lhs.x * scalar, lhs.y * scalar, lhs.z * scalar, lhs.w * scalar);
        public static Vector4 operator /(Vector4 lhs, float scalar) => new Vector4(lhs.x / scalar, lhs.y / scalar, lhs.z / scalar, lhs.w / scalar);
        public static bool operator !=(Vector4 lhs, Vector4 rhs) => !(lhs == rhs);
        public static bool operator ==(Vector4 lhs, Vector4 rhs) => lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z && lhs.w == rhs.w;

        public override bool Equals(object obj)
        {
            return obj is Vector4 vector4 && vector4 == this;
        }

        public override int GetHashCode()
        {
            return (x, y, z, w).GetHashCode();
        }

        public override string ToString()
        {
            return $"({x}, {y}, {z}, {w})";
        }
    }
}
