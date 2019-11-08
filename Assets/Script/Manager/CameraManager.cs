using HedgehogTeam.EasyTouch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SwipeDir
 { 
     idle,   
     left,
     right,
     up,
     down
 }

//摄像机为其子节点
public class CameraManager : MonoBehaviour
{
    [HideInInspector]
    public RoleCtrl currentRole;//橘色控制器
    [HideInInspector]
    public SwipeDir swipeDir = SwipeDir.idle;
    [HideInInspector]
    public Transform mainCamera;//摄像机
    [HideInInspector]
    public Vector2 swipeVector;

    public float verticalAngleLimit=10f;

    private float currentAngle = 0f;//记录当前在x轴方向旋转的度数
    
    private void OnEnable()
    {
        //EasyTouch.On_Swipe += OnSwipe;//会出现场景卸载之后，再次加载无法使用的问题？？？
    }

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

        mainCamera = transform.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentRole != null)
        {
            transform.position = currentRole.transform.position;
        }
    }

    public void OnSwipeAction(Gesture gesture)
    {        
        //transform.rotation = Quaternion.Lerp(transform.rotation, currentRole.transform.rotation, Time.deltaTime * 10f);
        AppDebug.Log("gesture.type:"+ gesture.swipe.ToString());

    }

    public void OnSwipe(Gesture gesture)
    {
        swipeVector = gesture.swipeVector;
        
        switch (GetCurrentSwipeDirection())
        {
            case SwipeDir.left:
            case SwipeDir.right:
                //不使用Quaternion 经旋转
                {
                    //Vector3 direction = new Vector3();
                    //direction.x = swipeVector.x;
                    //direction.z = swipeVector.y;
                    //direction.y = 0;
                    //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction.normalized), Time.deltaTime * 10);
                }

                float angleV = -1f;

                if (swipeVector.x < 0)
                {
                    angleV = 1f;
                }

                transform.Rotate(new Vector3(0, 1, 0), angleV);

                break;

            case SwipeDir.up://角度增大

            case SwipeDir.down://角度减小

                float angleH = 1f;

                if (swipeVector.y < 0)
                {
                    angleH = -1f;
                }

                bool canDo = false;

                if (Mathf.Abs(currentAngle) > verticalAngleLimit)
                {
                    if (currentAngle > 0 && angleH < 0)
                    {
                        canDo = true;
                    }

                    if (currentAngle < 0 && angleH > 0)
                    {
                        canDo = true;
                    }
                }
                else
                {
                    canDo = true;
                }

                if (canDo) {

                    mainCamera.Rotate(new Vector3(1, 0, 0), angleH);

                    currentAngle += angleH;
                }

                break;
        }
    }

    public SwipeDir GetCurrentSwipeDirection()
     {
         if (Mathf.Abs(swipeVector.x) > Mathf.Abs(swipeVector.y))
         {
             if (swipeVector.x > 0)
             {
                 return SwipeDir.right;
             }
             else if (swipeVector.x< 0)
             {
                 return SwipeDir.left;
             }
         }
         if (Mathf.Abs(swipeVector.x) < Mathf.Abs(swipeVector.y))
         {
             if (swipeVector.y > 0)
             {
                 return SwipeDir.up;
             }
             else if (swipeVector.y< 0)
             {
                 return SwipeDir.down;
             }
         }
 
         return SwipeDir.idle;
     }


}
