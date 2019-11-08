using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace LuaFramework
{
    public class MScenceManager : Manager
    {
        public string currentSenceName = "Scene_UI";

        public string lastSencenName = "Scene_UI";

        private AppView uiloading;

        private bool loadingShow=false;

        private AsyncOperation async;

        private float loadProgress =0f;

        public void LoadSence(string name)
        {
            if (currentSenceName.Equals(name))
            {
                return;
            }
            else
            {

                lastSencenName = currentSenceName;

                currentSenceName = name;

                StartCoroutine(loadSence(name));

                if (uiloading == null)
                {
                    uiloading = GameObject.Find("UILoading").GetComponent<AppView>();
                }

                uiloading.gameObject.SetActive(true);

                facade.SendMessageCommand(NotiConst.UPDATE_PROGRESS, "0");

                loadingShow = true;

            }
        }

        public void CloseLoading()
        {
            StartCoroutine(hideLoading());

        }

        IEnumerator hideLoading()
        {
            yield return new WaitForSeconds(1f);

            loadingShow = false;

            if (uiloading == null)
            {
                uiloading = GameObject.Find("UILoading").GetComponent<AppView>();
            }

            uiloading.gameObject.SetActive(false);

            AppDebug.Log("loading closed");
        }
        
        IEnumerator loadSence(string name)
        {
            
            async = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);

            yield return async;

            if (lastSencenName!= "Scene_UI")
            {
                SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(lastSencenName), UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
            }

            Util.CallMethod("Main", "OnLevelWasLoaded", currentSenceName, lastSencenName);

        }

        void Update()
        {
            if (async != null && async.isDone)
            {

                loadProgress = async.progress;

                facade.SendMessageCommand(NotiConst.UPDATE_PROGRESS, loadProgress.ToString());

            }
            else
            {
                if (uiloading != null && async != null && async.isDone && uiloading.gameObject.activeSelf)
                {
                    facade.SendMessageCommand(NotiConst.UPDATE_PROGRESS, "1");
                }
            }
        }

        void OnDestroy()
        {
            if (async!=null)
            {
                async = null;
            }

            if (uiloading != null)
            {
                uiloading = null;
            }

            Debug.Log("~MScenceManager was destroyed");
        }

    }
}
