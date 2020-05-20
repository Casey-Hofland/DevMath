using System;

namespace DevMath
{
    public struct Vector2
    {
        public static readonly Vector2 zero = new Vector2(0, 0);

        public float x;
        public float y;

        public float this[int key]
        {
            get => key == 0 ? x : key == 1 ? y : throw new IndexOutOfRangeException();
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
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public float SquaredMagnitude => (x * x) + (y * y);
        public float Magnitude => DevMath.SquareRoot(SquaredMagnitude);
        public Vector2 Normalized => this * (1 / Magnitude);

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static float Dot(Vector2 v, Vector2 w)
        {
            Vector2 vNormalized = v.Normalized;
            Vector2 wNormalized = w.Normalized;

            return vNormalized.x * wNormalized.x + vNormalized.y * wNormalized.y;
        }

        public static Vector2 Scale(Vector2 v, Vector2 w)
        {
            float uX = v.x * w.x;
            float uY = v.y * w.y;
            return new Vector2(uX, uY);
        }

        public static Vector2 Lerp(Vector2 a, Vector2 b, float t) => LerpUnclamped(a, b, DevMath.Clamp01(t));
        public static Vector2 LerpUnclamped(Vector2 a, Vector2 b, float t)
        {
            float uX = DevMath.LerpUnclamped(a.x, b.x, t);
            float uY = DevMath.LerpUnclamped(a.y, b.y, t);
            return new Vector2(uX, uY);
        }

        public static float Angle(Vector2 v) => Angle(v.x, v.y);
        public static float Angle(float x, float y) => (float)Math.Atan2(y, x);

        public static float Angle(Vector2 v, Vector2 w)
        {
            return Angle(w.x - v.x, w.y - v.y);
        }

        public static Vector2 DirectionFromAngle(float degrees) => DirectionFromRadians(degrees * DevMath.Deg2Rad);
        public static Vector2 DirectionFromRadians(float radians) => new Vector2((float)Math.Cos(radians), (float)Math.Sin(radians));

        public static float Distance(Vector2 v, Vector2 w) => (v - w).Magnitude;
        public static float SquaredDistance(Vector2 v, Vector2 w) => (v - w).SquaredMagnitude;

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs) => new Vector2(lhs.x + rhs.x, lhs.y + rhs.y);
        public static Vector2 operator -(Vector2 lhs, Vector2 rhs) => new Vector2(lhs.x - rhs.x, lhs.y - rhs.y);
        public static Vector2 operator -(Vector2 v) => new Vector2(-v.x, -v.y);
        public static Vector2 operator *(Vector2 lhs, float scalar) => new Vector2(lhs.x * scalar, lhs.y * scalar);
        public static Vector2 operator /(Vector2 lhs, float scalar) => new Vector2(lhs.x / scalar, lhs.y * scalar);
        public static bool operator !=(Vector2 lhs, Vector2 rhs) => !(lhs == rhs);
        public static bool operator ==(Vector2 lhs, Vector2 rhs) => lhs.x == rhs.x && lhs.y == rhs.y;

        public override bool Equals(object obj)
        {
            return obj is Vector2 vector2 && vector2 == this;
        }

        public override int GetHashCode()
        {
            return (x, y).GetHashCode();
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }
}
