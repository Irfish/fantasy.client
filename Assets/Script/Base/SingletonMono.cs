using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour 
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance==null)
            {
                GameObject go = new GameObject(typeof(T).Name);

                DontDestroyOnLoad(go);

                instance = go.GetOrCreateComponent<T>();

            }

            return instance;

        }
    }

    void OnEnable()
    {
        OnInit();
    }

    void Awake()
    {
        OnAwake();
    }


    void Start()
    {
        OnStart();
    }

    void Update()
    {
        OnUpdate();
    }

    void OnDestroy()
    {
        BeforeOnDestroy();
    }
    

    protected  virtual  void OnInit() { }

    protected virtual void OnAwake() { }

    protected virtual void OnStart() { }

    protected virtual void OnUpdate() { }

    protected virtual void BeforeOnDestroy() { }

}
