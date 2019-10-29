/* 
 LuaFramework Code By Jarjin lee 
*/
using System;

public interface IMessageLua
{
	string Name { get; }

	object Body { get; set; }
		
	string Type { get; set; }

    string ToString();
}

