using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class StringTools:Singleton<StringTools> 
{
    private  StringBuilder str=new StringBuilder();

    public StringTools Add(string s)
    {
        str.Append(s);
        return this;
    }

    public override void Dispose()
    {
        str.Clear();
        str = null;
        base.Dispose();
    }

    public override string ToString()
    {
        return str.ToString();
    }
}
