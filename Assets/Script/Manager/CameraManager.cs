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

    public Quaternion cameraRootOrigionRotion ;

    public Quaternion cameraOrigionRotion;

    public float verticalAngleLimit=10f;

    private float currentAngle = 0f;//记录当前在x轴方向旋转的度数
    
    private void OnEnable()
    {
        EasyTouch.On_Swipe += OnSwipe;//会出现场景卸载之后，再次加载无法使用的问题？？？

        EasyTouch.On_SwipeEnd += OnSwipeEnd;
    }

    // Start is called before the first frame update
    void Start()
    {
        cameraRootOrigionRotion = transform.rotation;

        mainCamera = transform.Find("MainCamera");

        cameraOrigionRotion = mainCamera.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentRole != null)
        {
            transform.position = currentRole.transform.position;
        }
    }

    public void OnSwipeEnd(Gesture gesture)
    {
        float a = 0f;

        Vector3 v =new Vector3(0,1,0);

        transform.rotation.ToAngleAxis(out a, out v);

        if (v.y < 0)//顺时针
        {
            currentRole.cameraAngle = -a;
        }
        else
        {
            currentRole.cameraAngle = a;
        }
    }

    public void OnSwipe(Gesture gesture)
    {
        swipeVector = gesture.swipeVector;
        
        switch (GetCurrentSwipeDirection())
        {
            case SwipeDir.left:
            case SwipeDir.right:
              
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

                if (canDo)
                {
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

    public void OnDisable()
    {
        EasyTouch.On_Swipe -= OnSwipe;

        EasyTouch.On_SwipeEnd -= OnSwipeEnd;
    }

}
