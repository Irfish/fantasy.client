using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapFollow : MonoBehaviour
{
    public static MinimapFollow Instance;

    void Start()
    {
        Instance = this;
    }

    public void Follow(Vector3 pos)
    {
        transform.LookAt(pos);
    }

    void Update()
    {
        
    }
}
