﻿using UnityEngine;
using LuaInterface;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

namespace LuaFramework {
    public class LuaBehaviour : View {
        private string data = null;
        private Dictionary<string, LuaFunction> buttons = new Dictionary<string, LuaFunction>();
        private Camera uiCamera;
        private Canvas canvas;
        protected void Awake() {
            Util.CallMethod(name, "Awake", gameObject);
            uiCamera = GameObject.FindWithTag("GuiCamera").GetComponent<Camera>();//transform.parent.GetComponent<Camera>();
            canvas = GameObject.Find("UIRootCanvas").GetComponent<Canvas>();//Canvas
        }

        protected void Start() {
            Util.CallMethod(name, "Start");
        }

        protected void OnClick() {
            Util.CallMethod(name, "OnClick");
        }

        
        protected void OnClickEvent(GameObject go) {
            Util.CallMethod(name, "OnClick", go);
        }

        /// <summary>
        /// 添加单击事件
        /// </summary>
        public void AddClick(GameObject go, LuaFunction luafunc) {
            if (go == null || luafunc == null) return;
            buttons.Add(go.name, luafunc);
            go.GetComponent<Button>().onClick.AddListener(
                delegate() {
                    luafunc.Call(go);
                }
            );
        }

        public void AddToggle(GameObject go ,LuaFunction luafunc) {
            if (go == null || luafunc == null) return;
            go.GetComponent<Toggle>().onValueChanged.AddListener(
                delegate (bool select) {
                    luafunc.Call(go, select);
                }
           );
        }

        public Vector2 CurrMousePosition(GameObject go)
        {
            Vector2 vecMouse;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out vecMouse);
            return vecMouse;
        }


        /// <summary>
        /// 删除单击事件
        /// </summary>
        /// <param name="go"></param>
        public void RemoveClick(GameObject go) {
            if (go == null) return;
            LuaFunction luafunc = null;
            if (buttons.TryGetValue(go.name, out luafunc)) {
                luafunc.Dispose();
                luafunc = null;
                buttons.Remove(go.name);
            }
        }

        /// <summary>
        /// 清除单击事件
        /// </summary>
        public void ClearClick() {
            foreach (var de in buttons) {
                if (de.Value != null) {
                    de.Value.Dispose();
                }
            }
            buttons.Clear();
        }

        //-----------------------------------------------------------------
        protected void OnDestroy() {
            ClearClick();
#if ASYNC_MODE
            string abName = name.ToLower().Replace("panel", "");
            ResManager.UnloadAssetBundle(abName + AppConst.ExtName);
#endif
            Util.ClearMemory();
            Debug.Log("~" + name + " was destroy!");
        }
    }
}