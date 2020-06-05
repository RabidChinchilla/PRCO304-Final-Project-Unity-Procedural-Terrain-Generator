using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateableData : ScriptableObject 
{
    public event System.Action OnValuesUpdated;
    public bool autoUpdate;

    #if UNITY_EDITOR
    //using this wont allow you to build so the #if makes it so that you only use this code if you're in the unity editor
    protected virtual void OnValidate()
    {
        if (autoUpdate)
        {
            UnityEditor.EditorApplication.update += NotifyOfUpdatedValues;
        }
    }

    public void NotifyOfUpdatedValues()
    {
        UnityEditor.EditorApplication.update -= NotifyOfUpdatedValues; //makes sure it's unsubscribed before it is used again
        if (OnValuesUpdated != null)
        {
            OnValuesUpdated();
        }
    }
    #endif

}
