using System;

namespace DevMath
{
    public static class DevMath
    {
        public const float PI = 3.14159274f;
        public const float Rad2Deg = 57.29578f;
        public const float Deg2Rad = 0.0174532924f;

        public static float Lerp(float a, float b, float t) => LerpUnclamped(a, b, Clamp01(t));
        public static float LerpUnclamped(float a, float b, float t) => a * (1 - t) + b * t;
    
        public static float DistanceTraveled(float startVelocity, float acceleration, float time)
        {
            return startVelocity * time + 0.5f * acceleration * time * time;
        }

        public static float Clamp(float value, float min, float max) => value < min ? min : value > max ? max : value;
        public static float Clamp01(float value) => Clamp(value, 0, 1);
        public static float RadToDeg(float radians) => radians * Rad2Deg;
        public static float DegToRad(float degrees) => degrees * Deg2Rad;

        public static float SquareRoot(float number)
        {
            const float precision = 10e-8f;
            float prev = 0.0f;
            float mid = number;
            while(Math.Abs(mid - prev) > precision)
            {
                prev = mid;
                mid = (mid + (number / mid)) * 0.5f;
            }
            return mid;
        }
    }
}
