using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FallOffGenerator
{
    public static float[,] GenerateFalloffMap(int size)
    {
        float[,] map = new float[size, size];

        for(int i = 0; i < size; i++)
        {
            for(int j = 0; j < size; j++)
            {
                float x = i / (float)size * 2 - 1; // to make it within a range of -1 to 1
                float y = j / (float)size * 2 - 1;

                float value = Mathf.Max(Mathf.Abs(x), Mathf.Abs(y)); // to find which value is closer to 1
                map[i, j] = Evaluate(value);
            }
        }

        return map;
    }

    static float Evaluate(float value)
    {
        float a = 3f;
        float b = 2.2f;
        //mathf.Pow returns float to the power of another float
        return Mathf.Pow(value, a) / (Mathf.Pow(value, a) + Mathf.Pow(b - b * value, a)); // helps return a better falloff map that creates larger islands
    }
}
