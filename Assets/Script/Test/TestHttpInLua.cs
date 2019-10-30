using LuaFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy.test
{
    public static class TestHttpInLua
    {
        public static void TestHttpGet(string url,string func){
           // fantasy.net.Http.Instance.SendGet(AppDefine.HttpURL + url, func);
        }

        public static void TestGetServiceTime()
        {
            fantasy.manager.UserManager.Instance.GetServerTime();
        }

        public static void TestHttpPost()
        {

        }
    }
}
