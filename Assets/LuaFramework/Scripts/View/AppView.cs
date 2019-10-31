using UnityEngine;
using LuaFramework;
using System.Collections.Generic;
using UnityEngine.UI;

public class AppView : View {
    private Slider m_ProgressSlider;
    private Text m_ProgressText;
    ///<summary>
    /// 监听的消息
    ///</summary>
    List<string> MessageList {
        get {
            return new List<string>()
            { 
                NotiConst.UPDATE_MESSAGE,
                NotiConst.UPDATE_EXTRACT,
                NotiConst.UPDATE_DOWNLOAD,
                NotiConst.UPDATE_PROGRESS,
            };
        }
    }

    void Awake() {
        RemoveMessage(this, MessageList);
        RegisterMessage(this, MessageList);
        m_ProgressSlider = transform.Find("progress/slider").gameObject.GetComponent<Slider>();
        m_ProgressText = transform.Find("progress/text").gameObject.GetComponent<Text>();
        m_ProgressSlider.value = 0f;
    }

    /// <summary>
    /// 处理View消息
    /// </summary>
    /// <param name="message"></param>
    public override void OnMessage(IMessageLua message) {
        string name = message.Name;
        object body = message.Body;
        switch (name) {
            case NotiConst.UPDATE_MESSAGE:      //更新消息
                UpdateMessage(body.ToString());
            break;
            case NotiConst.UPDATE_EXTRACT:      //更新解压
                UpdateExtract(body.ToString());
            break;
            case NotiConst.UPDATE_DOWNLOAD:     //更新下载
                UpdateDownload(body.ToString());
            break;
            case NotiConst.UPDATE_PROGRESS:     //更新下载进度
                UpdateProgress(body.ToString());
            break;
        }
    }

    public void UpdateMessage(string data) {
        m_ProgressText.text = data;
    }

    public void UpdateExtract(string data) {
        m_ProgressText.text = data;
    }

    public void UpdateDownload(string data) {
        m_ProgressText.text = data;
    }

    public void UpdateProgress(string data) {
        float p= float.Parse(data);
        m_ProgressText.text = p * 100 + "%";
        m_ProgressSlider.value = p;
        if (p == 0f)
        {
            AppDebug.Log("...");
        }
    }

}
