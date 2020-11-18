using System.IO;
using RFramework.Common.File.Utils;
using UnityEngine;

namespace Lua
{
    public static class LuaLoader
    {
        private static string LuaScriptsPath = "LuaScripts";

        static LuaLoader()
        {
            LuaScriptsPath = Path.Combine(
                Application.dataPath,
                LuaScriptsPath);
        }

        public static byte[] CustomLoader(ref string filepath)
        {
            return GetLuaFileContent(filepath);
        }

        /// <summary>
        /// 得到 Lua 文件 Resource 路径
        /// </summary>
        public static string GetLuaFileResPath(string path)
        {
            return $"{LuaScriptsPath}/{path.Replace(".", "/")}.lua";
        }

        public static byte[] GetLuaFileContent(string path)
        {
            return FileUtils.ReadAllBytes(GetLuaFileResPath(path));
        }
    }
}