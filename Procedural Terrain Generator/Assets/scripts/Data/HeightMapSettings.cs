using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HeightMapSettings : UpdateableData
{
    public NoiseSettings noiseSettings;

    public bool generateIsland;

    public float heightMultipier; //scales y axis
    public AnimationCurve heightCurve;

    public float minHeight
    {
        get
        {
            return  heightMultipier * heightCurve.Evaluate(0);
        }
    }

    public float maxHeight
    {
        get
        {
            return heightMultipier * heightCurve.Evaluate(1);
        }
    }

#if UNITY_EDITOR

    protected override void OnValidate() //this is to make sure all OnValidates run8
    {
        noiseSettings.ValidateValues();

        base.OnValidate();
    }
#endif
}
