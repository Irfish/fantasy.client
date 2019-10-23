using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private string m_Name;

    private int m_UserId;

    private string m_Tokon;

    private int m_TokenExpireTime;

    private int m_SessionId;

    private long m_RoomId;

    private int m_ChairId;

    public string Name
    {
        get {
            return m_Name;
        }
        set {
            m_Name = value;
        }
    }

    public string Token
    {
        get
        {
            return m_Tokon;
        }
        set
        {
            m_Tokon = value;
        }
    }

    public int UserId
    {
        get {
            return m_UserId;
        }
        set {
            m_UserId = value;
        }
    }

    public int SessionId
    {
        get {
            return m_SessionId;
        }
        set {
            m_SessionId = value;
        }
    }
    
    public int TokenExpireTime
    {
        get {
            return m_TokenExpireTime;
        }
        set {
            m_TokenExpireTime = value;
        }
    }

    public long RoomId
    {
        get
        {
            return m_RoomId;
        }
        set
        {
            m_RoomId = value;
        }
    }

    public int ChairId
    {
        get
        {
            return m_ChairId;
        }
        set
        {
            m_ChairId = value;
        }
    }

}
