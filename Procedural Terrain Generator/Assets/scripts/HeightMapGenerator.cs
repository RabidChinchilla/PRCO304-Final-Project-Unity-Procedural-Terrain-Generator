﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HeightMapGenerator
{
    static float[,] fallOffMap;


    public static HeightMap GenerateHeightMap(int width, int height, HeightMapSettings settings, Vector2 sampleCentre)
    {
        float[,] values = Noise.GenerateNoiseMap(width, height, settings.noiseSettings, sampleCentre);

        AnimationCurve heightCurve_threadsafe = new AnimationCurve(settings.heightCurve.keys); //gets all keys defined in the animation curve

        float minValue = float.MaxValue;
        float maxValue = float.MinValue;

        if (settings.generateIsland)
        {
            if (fallOffMap == null)
            {
                fallOffMap = FallOffGenerator.GenerateFalloffMap(width);
            }
        }

        for (int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                //adjusts values by evaluating to the height curve and multiplying by the height multiplier
                values[i, j] *= heightCurve_threadsafe.Evaluate(values[i, j] - (settings.generateIsland ? fallOffMap[i, j] : 0)) * settings.heightMultipier;

                if (values[i,j] > maxValue)
                {
                    maxValue = values[i, j];
                }

                if(values[i,j] < minValue)
                {
                    minValue = values[i, j];
                }
            }
        }

        return new HeightMap(values, minValue, maxValue);
    }
}

public struct HeightMap
{
    public readonly float[,] values;
    public readonly float minValue;
    public readonly float maxValue;

    public HeightMap(float[,] values, float minValue, float maxValue)
    {
        this.values = values;
        this.minValue = minValue;
        this.maxValue = maxValue;
    }
}
