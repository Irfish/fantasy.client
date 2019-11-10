using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EasyTouchMove : MonoBehaviour, IDragHandler, IEndDragHandler
{
    //图标移动最大半径
    public float maxRadius = 50;

    public float speed = 0f;
    //初始化背景图标位置
    private Vector2 moveBackPos;

    private float horizontal = 0;

    private float vertical = 0;

    public Action<int> OnRoleFight;

    public Action<int> OnRoleSkill;

    public float Horizontal
    {
        get { return horizontal; }
    }

    public float Vertical
    {
        get { return vertical; }
    }

    // Use this for initialization
    void Start()
    {
        //初始化背景图标位置
        moveBackPos = transform.parent.transform.position;
    }

    void Update()
    {
        horizontal = transform.localPosition.x;

        vertical = transform.localPosition.y;
    }

    /// <summary>
    /// 当鼠标开始拖拽时
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        //获取鼠标位置与初始位置之间的向量
        Vector2 oppsitionVec = eventData.position - moveBackPos;
        //获取向量的长度
        float distance = Vector3.Magnitude(oppsitionVec);
        //最小值与最大值之间取半径
        float radius = Mathf.Clamp(distance, 0, maxRadius);
        //根据半径来控制移动速度
        speed = radius;
        //限制半径长度
        transform.position = moveBackPos + oppsitionVec.normalized * radius;
    }

    /// <summary>
    /// 当鼠标停止拖拽时
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = moveBackPos;

        transform.localPosition = Vector3.zero;
    }

    public void OnClickBtnRoleFight()
    {
        OnRoleFight.Invoke(2);
    }

    public void OnClickBtnRoleSkill1()
    {
        OnRoleSkill.Invoke(1);
    }

    public void OnClickBtnRoleSkill2()
    {
        OnRoleSkill.Invoke(3);
    }

    public void OnClickBtnRoleSkill3()
    {
        OnRoleSkill.Invoke(4);
    }

    public void OnClickBtnRoleSkill4()
    {
        OnRoleSkill.Invoke(5);
    }
    
}
