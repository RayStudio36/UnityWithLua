using System;
using System.Collections;
using RFramework.Common.Log;
using RFramework.Common.Singleton;
using UnityEngine;
using XLua;

namespace Lua
{
    public class LuaManager : MonoSingleton<LuaManager>
    {
        private const string ENTRY_FILE_NAME = "main";
        private const string ENTRY_FILE_START_FUNC = "start";
        private const string ENTRY_FILE_UPDATE_FUNC = "update";
        private const string ENTRY_FILE_DESTROY_FUNC = "destroy";

        private LuaEnv _luaEnv;
        public LuaEnv LuaEnv => _luaEnv;

        private Action _startFunc;
        private Action<float> _updateFunc;
        private Action _destroyFunc;

        #region LifeCycle

        protected override void OnInit()
        {
            base.OnInit();

            LuaStart();
        }

        protected override void OnFree()
        {
            base.OnFree();

            Dispose();
        }

        private void Update()
        {
            if (_luaEnv != null)
            {
                try
                {
                    _updateFunc?.Invoke(Time.deltaTime);
                }
                catch (Exception e)
                {
                    RLog.LogError(e);
                }

                _luaEnv.Tick();

                if (Time.frameCount % 100 == 0)
                {
                    _luaEnv.FullGc();
                }
            }
        }

        #endregion

        #region Public

        public void Restart()
        {
            StartCoroutine(RestartCo(DestroyEnvCo()));
        }

        public void SafeDoString(string scriptContent)
        {
            if (_luaEnv != null)
            {
                try
                {
                    _luaEnv.DoString(scriptContent);
                }
                catch (Exception e)
                {
                    RLog.LogError(
                        $"Lua Exception: {e.Message}\n {e.StackTrace}");
                }
            }
        }

        public void LoadScript(string scriptName)
        {
            SafeDoString($"require('{scriptName}')");
        }

        #endregion

        #region Private

        private void InitLuaEnv()
        {
            _luaEnv = new LuaEnv();
            if (_luaEnv != null)
            {
                _luaEnv.AddLoader(LuaLoader.CustomLoader);
            }
            else
            {
                RLog.LogError("Lua env init failed.");
            }
        }

        private void LoadMainScript()
        {
            LoadScript(ENTRY_FILE_NAME);
            _luaEnv.Global.Get(ENTRY_FILE_START_FUNC, out _startFunc);
            _luaEnv.Global.Get(ENTRY_FILE_UPDATE_FUNC, out _updateFunc);
            _luaEnv.Global.Get(ENTRY_FILE_DESTROY_FUNC, out _destroyFunc);
        }

        private void LuaStart()
        {
            InitLuaEnv();
            LoadMainScript();

            try
            {
                _startFunc?.Invoke();
            }
            catch (Exception e)
            {
                RLog.LogError(e);
            }
        }

        private IEnumerator RestartCo(IEnumerator beforeCo)
        {
            yield return beforeCo;

            LuaStart();
        }

        private IEnumerator DestroyEnvCo()
        {
            try
            {
                _destroyFunc?.Invoke();
            }
            catch (Exception e)
            {
                RLog.LogError(e);
            }

            _startFunc = null;
            _updateFunc = null;
            _destroyFunc = null;

            yield return null;

            Dispose();
        }

        private void Dispose()
        {
            if (_luaEnv != null)
            {
                try
                {
                    _startFunc = null;
                    _updateFunc = null;
                    _destroyFunc = null;

                    _luaEnv.FullGc();

                    _luaEnv.Dispose();
                    _luaEnv = null;
                }
                catch (Exception e)
                {
                    RLog.LogError(
                        $"Lua Exception : {e.Message}\n {e.StackTrace}");
                }
            }
        }

        #endregion
    }
}
