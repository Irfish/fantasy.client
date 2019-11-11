using HedgehogTeam.EasyTouch;
using UnityEngine;

/// <summary>
/// 控制摄像机
/// </summary>
public class WorldCameraCtrl : MonoBehaviour
{
    public static WorldCameraCtrl Instance;

    public GameObject m_cameraUpAndDown;

    public GameObject m_cameraZoomContainer;

    public GameObject m_cameraContainer;

    private Vector2 m_swipeVector;

    private void Awake()
    {
        Instance = this;
    }

    void OnEnable()
    {
        EasyTouch.On_Swipe += OnSwipe;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Init()
    {
        m_cameraUpAndDown.transform.localEulerAngles = new Vector3(Mathf.Clamp(m_cameraUpAndDown.transform.localEulerAngles.x, 1f, 60f), 0, 0);

        m_cameraContainer.transform.localPosition = new Vector3(0, 0, Mathf.Clamp(m_cameraContainer.transform.localPosition.z, -6, 3f));
    }

    //获取当前摄像机旋转的角度
    public float GetRotationAngle()
    {
        return transform.localEulerAngles.y;
    }

    //摄像机旋转  1:左, 2:右
    public void SetCameraRotate(int type) 
    {
        transform.Rotate(0,10*Time.deltaTime*5*(type==1?-1:1),0);
    }

    //摄像机上下  1:上, 2:下
    public void SetCameraUpAndDown(int type)
    {
       m_cameraUpAndDown.transform.Rotate(10*Time.deltaTime*10 * (type == 1 ? -1 : 1), 0, 0);
       //限制角度
       m_cameraUpAndDown.transform.localEulerAngles = new Vector3(Mathf.Clamp(m_cameraUpAndDown.transform.localEulerAngles.x, 5f, 60f),0,0);
    }
    //摄像机缩放 1:拉近, 2;远离
    public void SetCameraZoom(int type)
    {
        m_cameraContainer.transform.Translate(Vector3.forward*10*Time.deltaTime*5* (type == 1 ? -1 : 1));
        //限制距离
        m_cameraContainer.transform.localPosition = new Vector3(0, 0, Mathf.Clamp(m_cameraContainer.transform.localPosition.z, -6, 3f));
    }

    public void AutoLookAt(Vector3 pos)
    {
        m_cameraZoomContainer.transform.LookAt(pos);
    }

    public void OnSwipe(Gesture gesture)
    {
        m_swipeVector = gesture.swipeVector;

        switch (GetCurrentSwipeDirection())
        {
            case SwipeDir.left:

                SetCameraRotate(1);

                break;

            case SwipeDir.right:

                SetCameraRotate(2);

                break;

            case SwipeDir.up://角度增大

                SetCameraUpAndDown(1);

                break;

            case SwipeDir.down://角度减小

                SetCameraUpAndDown(2);

                break;
        }
    }

    public SwipeDir GetCurrentSwipeDirection()
    {
        if (Mathf.Abs(m_swipeVector.x) > Mathf.Abs(m_swipeVector.y))
        {
            if (m_swipeVector.x > 0)
            {
                return SwipeDir.right;
            }
            else if (m_swipeVector.x < 0)
            {
                return SwipeDir.left;
            }
        }
        if (Mathf.Abs(m_swipeVector.x) < Mathf.Abs(m_swipeVector.y))
        {
            if (m_swipeVector.y > 0)
            {
                return SwipeDir.up;
            }
            else if (m_swipeVector.y < 0)
            {
                return SwipeDir.down;
            }
        }

        return SwipeDir.idle;
    }

    public void OnDisable()
    {
        EasyTouch.On_Swipe -= OnSwipe;
    }
}

public enum SwipeDir
{
    idle,
    left,
    right,
    up,
    down
}