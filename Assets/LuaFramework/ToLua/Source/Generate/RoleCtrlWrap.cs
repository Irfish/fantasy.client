﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class RoleCtrlWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(RoleCtrl), typeof(UnityEngine.MonoBehaviour));
		L.RegFunction("CheckDir", CheckDir);
		L.RegFunction("ToIdle", ToIdle);
		L.RegFunction("Fight", Fight);
		L.RegFunction("Skill", Skill);
		L.RegFunction("PlayEffect", PlayEffect);
		L.RegFunction("StopEffect", StopEffect);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("roleName", get_roleName, set_roleName);
		L.RegVar("LockEnemy", get_LockEnemy, set_LockEnemy);
		L.RegVar("easyTouchMove", get_easyTouchMove, set_easyTouchMove);
		L.RegVar("CurrRoleFSMMgr", get_CurrRoleFSMMgr, set_CurrRoleFSMMgr);
		L.RegVar("isMoveing", get_isMoveing, set_isMoveing);
		L.RegVar("characterController", get_characterController, set_characterController);
		L.RegVar("OnRoleDie", get_OnRoleDie, set_OnRoleDie);
		L.RegVar("Animator", get_Animator, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CheckDir(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			RoleCtrl obj = (RoleCtrl)ToLua.CheckObject<RoleCtrl>(L, 1);
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			float arg1 = (float)LuaDLL.luaL_checknumber(L, 3);
			UnityEngine.Vector3 o = obj.CheckDir(arg0, arg1);
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToIdle(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RoleCtrl obj = (RoleCtrl)ToLua.CheckObject<RoleCtrl>(L, 1);
			obj.ToIdle();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Fight(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RoleCtrl obj = (RoleCtrl)ToLua.CheckObject<RoleCtrl>(L, 1);
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.Fight(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Skill(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RoleCtrl obj = (RoleCtrl)ToLua.CheckObject<RoleCtrl>(L, 1);
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.Skill(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PlayEffect(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RoleCtrl obj = (RoleCtrl)ToLua.CheckObject<RoleCtrl>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			obj.PlayEffect(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StopEffect(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RoleCtrl obj = (RoleCtrl)ToLua.CheckObject<RoleCtrl>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			obj.StopEffect(arg0);
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
	static int get_roleName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RoleCtrl obj = (RoleCtrl)o;
			string ret = obj.roleName;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index roleName on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LockEnemy(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RoleCtrl obj = (RoleCtrl)o;
			RoleCtrl ret = obj.LockEnemy;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index LockEnemy on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_easyTouchMove(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RoleCtrl obj = (RoleCtrl)o;
			EasyTouchMove ret = obj.easyTouchMove;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index easyTouchMove on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CurrRoleFSMMgr(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RoleCtrl obj = (RoleCtrl)o;
			RoleFSMManager ret = obj.CurrRoleFSMMgr;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index CurrRoleFSMMgr on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isMoveing(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RoleCtrl obj = (RoleCtrl)o;
			bool ret = obj.isMoveing;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index isMoveing on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_characterController(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RoleCtrl obj = (RoleCtrl)o;
			UnityEngine.CharacterController ret = obj.characterController;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index characterController on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_OnRoleDie(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RoleCtrl obj = (RoleCtrl)o;
			System.Action<RoleCtrl> ret = obj.OnRoleDie;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index OnRoleDie on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Animator(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RoleCtrl obj = (RoleCtrl)o;
			UnityEngine.Animator ret = obj.Animator;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index Animator on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_roleName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RoleCtrl obj = (RoleCtrl)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.roleName = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index roleName on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_LockEnemy(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RoleCtrl obj = (RoleCtrl)o;
			RoleCtrl arg0 = (RoleCtrl)ToLua.CheckObject<RoleCtrl>(L, 2);
			obj.LockEnemy = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index LockEnemy on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_easyTouchMove(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RoleCtrl obj = (RoleCtrl)o;
			EasyTouchMove arg0 = (EasyTouchMove)ToLua.CheckObject<EasyTouchMove>(L, 2);
			obj.easyTouchMove = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index easyTouchMove on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_CurrRoleFSMMgr(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RoleCtrl obj = (RoleCtrl)o;
			RoleFSMManager arg0 = (RoleFSMManager)ToLua.CheckObject<RoleFSMManager>(L, 2);
			obj.CurrRoleFSMMgr = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index CurrRoleFSMMgr on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isMoveing(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RoleCtrl obj = (RoleCtrl)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.isMoveing = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index isMoveing on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_characterController(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RoleCtrl obj = (RoleCtrl)o;
			UnityEngine.CharacterController arg0 = (UnityEngine.CharacterController)ToLua.CheckObject<UnityEngine.CharacterController>(L, 2);
			obj.characterController = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index characterController on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_OnRoleDie(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RoleCtrl obj = (RoleCtrl)o;
			System.Action<RoleCtrl> arg0 = (System.Action<RoleCtrl>)ToLua.CheckDelegate<System.Action<RoleCtrl>>(L, 2);
			obj.OnRoleDie = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index OnRoleDie on a nil value");
		}
	}
}

