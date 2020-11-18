using System;
using System.Collections.Generic;
using XLua;

namespace Lua
{
    public class LuaTypeDefine
    {
        [CSharpCallLua]
        public delegate void LuaUpdate(float f);

        [CSharpCallLua] public static List<Type> CSharpCallLuaTypes =
            new List<Type>()
            {
            };

        [LuaCallCSharp] public static List<Type> LuaCallCSharpTypes =
            new List<Type>()
            {
            };
    }
}