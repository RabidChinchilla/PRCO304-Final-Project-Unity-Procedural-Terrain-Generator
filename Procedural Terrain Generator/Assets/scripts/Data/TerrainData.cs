using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TerrainData : UpdateableData
{
    //used to create terrain data assets for data storage

    public float uniformScale = 2f; //adjust if you want a larger map, scales x, y and z axis

    public bool useFlatShading;

    public bool useFallOff;

    public float meshHeightMultiplier; //scales y axis
    public AnimationCurve meshHeightCurve;
}
