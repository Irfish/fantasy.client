using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExp 
{
    public static T GetOrCreateComponent<T>(this GameObject go) where T : MonoBehaviour
    {
        T t = go.GetComponent<T>();
        if(t==null)
        {
            t = go.AddComponent<T>();
        }
        return t;
    }
}
