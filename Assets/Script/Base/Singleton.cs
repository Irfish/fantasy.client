
using System;
/// <summary>
/// 泛型单例
/// 为什么要实现接口 IDisposable
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> : IDisposable where T : new()
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new T();
            }
            return instance;
        }
    }

    public virtual void Dispose()
    {

    }

}
