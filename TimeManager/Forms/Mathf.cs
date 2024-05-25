namespace System
{
    public static class Mathf
    {
        public static int Clamp(int v, int min, int max)
        {
            if (v < min) return min;
            else if (v >= min && v < max) return v;
            else return max;
        }

        public static float Clampf(float v, float min, float max)
        {
            if (v < min) return min;
            else if (v >= min && v < max) return v;
            else return max;
        }
    }
}
