using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MeshSettings : UpdateableData
{
    //used to create terrain data assets for data storage

    public const int numSupportedLODs = 5;
    public const int numSupportedChunkSizes = 9;
    public const int numSupportedFlatshadedChunkSizes = 3;

    public static readonly int[] supportedChunkSizes = { 48, 72, 96, 120, 144, 168, 192, 216, 240 };

    public float meshScale = 2.5f; //adjust if you want a larger map, scales x, y and z axis

    public bool lowPolyMode;

    [Range(0, numSupportedChunkSizes - 1)]
    public int chunkSizeIndex;

    [Range(0, numSupportedFlatshadedChunkSizes - 1)]
    public int flatshadedChunkSizeIndex;


    public int numVerticesPerLine //number of vertices per line of a mesh rendered with a level of detail of 0 //inclues 2 extra vertices that are excluded from final mesh but used for calculating normals
    {
        get
        {
            //Ternary Operator
            return supportedChunkSizes[(lowPolyMode) ? flatshadedChunkSizeIndex : chunkSizeIndex] + 5;
        }
    }

    public float meshWorldSize
    {
        get
        {
            return (numVerticesPerLine - 3) * meshScale;
        }
    }
}
