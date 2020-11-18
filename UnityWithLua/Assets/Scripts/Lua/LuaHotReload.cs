using RFramework.Common.Log;
using UnityEngine;

namespace Lua
{
    public class LuaHotReload : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftControl) &&
                Input.GetKeyDown(KeyCode.R))
            {
                LuaManager.Instance.Restart();
                
                RLog.Log("Lua hot reload");
            }
        }
    }
}