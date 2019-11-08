using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaFramework;

/// <summary>
/// 雪地
/// </summary>
public class WordSceneManagerXueDi : MonoBehaviour
{
    //角色控制器
    public RoleCtrl roleCtrl;
    //角色出生点
    public Transform roleBornpostion;

    // Start is called before the first frame update
    void Start()
    {
        if (roleBornpostion==null) //尝试获取角色出生点
        {
            GameObject obj= GameObject.Find("RoleBornPoint");

            if (obj)
            {
                roleBornpostion = obj.transform;
            }
            else
            {
                AppDebug.Log("can not found role born point, please create an empty gameobject to be a role born point");
            }
        }

        LoadPlayer();

    }

    //从assetbundle中加载
    public void LoadPlayer()
    {
        if (roleCtrl != null) return; //测试时可通过手动添加
            
        ResourceManager resourceManager =  LuaHelper.GetResManager();
        //TOTO 此处会根据玩家学者的角色选择对应的名称（跟根据配置表配置）
        string roleName = "Role_MainPlayer_Cike"; //刺客

        //string roleName = "Role_MainPlayer_Fashi";//法师

        //string roleName = "Role_MainPlayer_Juchui";//肉塔

        //string roleName = "Role_MainPlayer_Zhanshi";//战士

        GameObject prefab = resourceManager.LoadAsset<GameObject>("role", roleName);

        if (prefab == null) return;

        GameObject go = Instantiate(prefab) as GameObject;

        go.name = "MainRole";

        go.transform.SetParent(roleBornpostion);

        go.transform.localScale = Vector3.one;

        go.transform.localPosition = Vector3.zero;

        roleCtrl = go.GetOrCreateComponent<RoleCtrl>();

        roleCtrl.roleName = roleName; 

        roleCtrl.CurrRoleFSMMgr = new RoleFSMManager(roleCtrl);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        roleCtrl = null;
    }
}
