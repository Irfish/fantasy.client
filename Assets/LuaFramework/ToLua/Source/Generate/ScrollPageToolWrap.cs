﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class ScrollPageToolWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(ScrollPageTool), typeof(UnityEngine.MonoBehaviour));
		L.RegFunction("Start", Start);
		L.RegFunction("InitPageList", InitPageList);
		L.RegFunction("ResetPageCount", ResetPageCount);
		L.RegFunction("RestToPage", RestToPage);
		L.RegFunction("ResetPageName", ResetPageName);
		L.RegFunction("InitManager", InitManager);
		L.RegFunction("OnBeginDrag", OnBeginDrag);
		L.RegFunction("OnEndDrag", OnEndDrag);
		L.RegFunction("ChangePage", ChangePage);
		L.RegFunction("ChangePageText", ChangePageText);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("pageLastButton", get_pageLastButton, set_pageLastButton);
		L.RegVar("pageNextButton", get_pageNextButton, set_pageNextButton);
		L.RegVar("pageNumText", get_pageNumText, set_pageNumText);
		L.RegVar("itemConnect", get_itemConnect, set_itemConnect);
		L.RegVar("m_dragNum", get_m_dragNum, set_m_dragNum);
		L.RegVar("scrollRect", get_scrollRect, set_scrollRect);
		L.RegVar("SetButtonStatus", null, set_SetButtonStatus);
		L.RegVar("GetPageNum", get_GetPageNum, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Start(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			ScrollPageTool obj = (ScrollPageTool)ToLua.CheckObject<ScrollPageTool>(L, 1);
			obj.Start();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InitPageList(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			ScrollPageTool obj = (ScrollPageTool)ToLua.CheckObject<ScrollPageTool>(L, 1);
			obj.InitPageList();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetPageCount(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			ScrollPageTool obj = (ScrollPageTool)ToLua.CheckObject<ScrollPageTool>(L, 1);
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.ResetPageCount(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RestToPage(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			ScrollPageTool obj = (ScrollPageTool)ToLua.CheckObject<ScrollPageTool>(L, 1);
			obj.RestToPage();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetPageName(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			ScrollPageTool obj = (ScrollPageTool)ToLua.CheckObject<ScrollPageTool>(L, 1);
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			string arg1 = ToLua.CheckString(L, 3);
			obj.ResetPageName(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InitManager(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				ScrollPageTool obj = (ScrollPageTool)ToLua.CheckObject<ScrollPageTool>(L, 1);
				int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
				obj.InitManager(arg0);
				return 0;
			}
			else if (count == 3 && TypeChecker.CheckTypes<UnityEngine.Vector2>(L, 3))
			{
				ScrollPageTool obj = (ScrollPageTool)ToLua.CheckObject<ScrollPageTool>(L, 1);
				int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
				UnityEngine.Vector2 arg1 = ToLua.ToVector2(L, 3);
				obj.InitManager(arg0, arg1);
				return 0;
			}
			else if (count == 3 && TypeChecker.CheckTypes<int>(L, 3))
			{
				ScrollPageTool obj = (ScrollPageTool)ToLua.CheckObject<ScrollPageTool>(L, 1);
				int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
				int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
				obj.InitManager(arg0, arg1);
				return 0;
			}
			else if (count == 4 && TypeChecker.CheckTypes<UnityEngine.Vector2, bool>(L, 3))
			{
				ScrollPageTool obj = (ScrollPageTool)ToLua.CheckObject<ScrollPageTool>(L, 1);
				int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
				UnityEngine.Vector2 arg1 = ToLua.ToVector2(L, 3);
				bool arg2 = LuaDLL.lua_toboolean(L, 4);
				obj.InitManager(arg0, arg1, arg2);
				return 0;
			}
			else if (count == 4 && TypeChecker.CheckTypes<int, bool>(L, 3))
			{
				ScrollPageTool obj = (ScrollPageTool)ToLua.CheckObject<ScrollPageTool>(L, 1);
				int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
				int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
				bool arg2 = LuaDLL.lua_toboolean(L, 4);
				obj.InitManager(arg0, arg1, arg2);
				return 0;
			}
			else if (count == 5)
			{
				ScrollPageTool obj = (ScrollPageTool)ToLua.CheckObject<ScrollPageTool>(L, 1);
				int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
				UnityEngine.Vector2 arg1 = ToLua.ToVector2(L, 3);
				bool arg2 = LuaDLL.luaL_checkboolean(L, 4);
				int arg3 = (int)LuaDLL.luaL_checknumber(L, 5);
				obj.InitManager(arg0, arg1, arg2, arg3);
				return 0;
			}
			else if (count == 6)
			{
				ScrollPageTool obj = (ScrollPageTool)ToLua.CheckObject<ScrollPageTool>(L, 1);
				int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
				UnityEngine.Vector2 arg1 = ToLua.ToVector2(L, 3);
				bool arg2 = LuaDLL.luaL_checkboolean(L, 4);
				int arg3 = (int)LuaDLL.luaL_checknumber(L, 5);
				bool arg4 = LuaDLL.luaL_checkboolean(L, 6);
				obj.InitManager(arg0, arg1, arg2, arg3, arg4);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: ScrollPageTool.InitManager");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnBeginDrag(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			ScrollPageTool obj = (ScrollPageTool)ToLua.CheckObject<ScrollPageTool>(L, 1);
			UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)ToLua.CheckObject<UnityEngine.EventSystems.PointerEventData>(L, 2);
			obj.OnBeginDrag(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnEndDrag(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			ScrollPageTool obj = (ScrollPageTool)ToLua.CheckObject<ScrollPageTool>(L, 1);
			UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)ToLua.CheckObject<UnityEngine.EventSystems.PointerEventData>(L, 2);
			obj.OnEndDrag(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ChangePage(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				ScrollPageTool obj = (ScrollPageTool)ToLua.CheckObject<ScrollPageTool>(L, 1);
				int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
				obj.ChangePage(arg0);
				return 0;
			}
			else if (count == 3)
			{
				ScrollPageTool obj = (ScrollPageTool)ToLua.CheckObject<ScrollPageTool>(L, 1);
				int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
				bool arg1 = LuaDLL.luaL_checkboolean(L, 3);
				obj.ChangePage(arg0, arg1);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: ScrollPageTool.ChangePage");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ChangePageText(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			ScrollPageTool obj = (ScrollPageTool)ToLua.CheckObject<ScrollPageTool>(L, 1);
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.ChangePageText(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Equality(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object arg1 = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool o = arg0 == arg1;
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pageLastButton(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ScrollPageTool obj = (ScrollPageTool)o;
			UnityEngine.UI.Button ret = obj.pageLastButton;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index pageLastButton on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pageNextButton(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ScrollPageTool obj = (ScrollPageTool)o;
			UnityEngine.UI.Button ret = obj.pageNextButton;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index pageNextButton on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pageNumText(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ScrollPageTool obj = (ScrollPageTool)o;
			UnityEngine.UI.Text ret = obj.pageNumText;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index pageNumText on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_itemConnect(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ScrollPageTool obj = (ScrollPageTool)o;
			UnityEngine.UI.GridLayoutGroup ret = obj.itemConnect;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index itemConnect on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_m_dragNum(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ScrollPageTool obj = (ScrollPageTool)o;
			int ret = obj.m_dragNum;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index m_dragNum on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_scrollRect(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ScrollPageTool obj = (ScrollPageTool)o;
			UnityEngine.UI.ScrollRect ret = obj.scrollRect;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index scrollRect on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GetPageNum(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ScrollPageTool obj = (ScrollPageTool)o;
			int ret = obj.GetPageNum;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index GetPageNum on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_pageLastButton(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ScrollPageTool obj = (ScrollPageTool)o;
			UnityEngine.UI.Button arg0 = (UnityEngine.UI.Button)ToLua.CheckObject<UnityEngine.UI.Button>(L, 2);
			obj.pageLastButton = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index pageLastButton on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_pageNextButton(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ScrollPageTool obj = (ScrollPageTool)o;
			UnityEngine.UI.Button arg0 = (UnityEngine.UI.Button)ToLua.CheckObject<UnityEngine.UI.Button>(L, 2);
			obj.pageNextButton = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index pageNextButton on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_pageNumText(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ScrollPageTool obj = (ScrollPageTool)o;
			UnityEngine.UI.Text arg0 = (UnityEngine.UI.Text)ToLua.CheckObject<UnityEngine.UI.Text>(L, 2);
			obj.pageNumText = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index pageNumText on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_itemConnect(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ScrollPageTool obj = (ScrollPageTool)o;
			UnityEngine.UI.GridLayoutGroup arg0 = (UnityEngine.UI.GridLayoutGroup)ToLua.CheckObject<UnityEngine.UI.GridLayoutGroup>(L, 2);
			obj.itemConnect = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index itemConnect on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m_dragNum(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ScrollPageTool obj = (ScrollPageTool)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.m_dragNum = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index m_dragNum on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_scrollRect(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ScrollPageTool obj = (ScrollPageTool)o;
			UnityEngine.UI.ScrollRect arg0 = (UnityEngine.UI.ScrollRect)ToLua.CheckObject<UnityEngine.UI.ScrollRect>(L, 2);
			obj.scrollRect = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index scrollRect on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_SetButtonStatus(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ScrollPageTool obj = (ScrollPageTool)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.SetButtonStatus = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index SetButtonStatus on a nil value");
		}
	}
}

