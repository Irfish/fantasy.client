using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public RoleCtrl currentRole;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("RoleBornPoint");

        if (obj)
        {
            currentRole = obj.GetComponentInChildren<RoleCtrl>();  
        }
        else
        {
            AppDebug.Log("can not found role born point, please create an empty gameobject to be a role born point");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentRole != null) {
            transform.position = currentRole.transform.position;
        }
    }
}
